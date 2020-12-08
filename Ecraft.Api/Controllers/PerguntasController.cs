using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ecraft.Api.Data.Repositories.UnitsOfWork;
using Ecraft.Api.Models;
using Ecraft.Api.Models.Join;
using Ecraft.Api.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {

        private readonly UnitOfWorkPerguntas _unit;
        private readonly UnitOfWorkTags _tags;

        public PerguntasController(UnitOfWorkPerguntas unit)
        {
            _unit = unit;
        }

        // GET: api/Perguntas
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string param)
        {
            return Ok(await _unit.Perguntas.GetAsync());
        }

        // GET: api/Perguntas/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProjeto(int id)
        {
            var obj = await _unit.GetById(id);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        // POST: api/Perguntas
        [HttpPost]
        public async Task<ActionResult<Perguntas>> Post(Perguntas obj)
        {
            try
            {
                obj.Date = DateTime.Now;
                var tagList = new List<Tags>();
                foreach (var item in obj.Tags)
                {
                    var tag = new Tags() { Tag = item.Title };
                    var tagPerg = new TagPergunta()
                    {
                        Perguntas = obj,
                        Tags = tag
                    };
                    var tagExist = _unit.Tag.Get(x => x.Tag == item.Title);
                    if (tagExist.Count == 0)
                    {
                        _unit.Tag.Insert(tag);
                        _unit.TagPerg.Insert(tagPerg);
                    }
                }
                _unit.Perguntas.Insert(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // PUT: api/Perguntas/5
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(Perguntas obj)
        {
            try
            {
                var entityExist = _unit.Perguntas.EntityExists(obj);
                if (!entityExist) return NotFound();
                _unit.Perguntas.Update(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Perguntas/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _unit.Perguntas.DeleteAsync(id);
                await _unit.CommitAssync();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // RESPOSTAS
        [HttpPost]
        [Route("rep")]
        public async Task PostResposta(PerguntasViewModel obj)
        {
            var pergunta = _unit.Perguntas.GetByIdAssync(obj.Id);
            var tags = (List<Tags>) obj.Tags;
            foreach (var item in tags) _tags.Tag.Insert(item);
        }

    }
}
