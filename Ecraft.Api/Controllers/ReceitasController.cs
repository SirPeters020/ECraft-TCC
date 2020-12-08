using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecraft.Api.Data.Repositories.UnitsOfWork;
using Ecraft.Api.Models;
using Ecraft.Api.Models.Join;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly UnitOfWorkReceitas _unit;

        public ReceitasController(UnitOfWorkReceitas unit)
        {
            _unit = unit;
        }

        // GET: api/Receitas
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string param)
        {
            return Ok(await _unit.Receitas.GetAsync());
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjeto(int id)
        {
            var obj = await _unit.GetById(id);

            if(obj == null) return NotFound();

            return Ok(obj);
        }

        // POST: api/Receitas
        [HttpPost]
        public async Task<ActionResult<Receitas>> Post(Receitas obj)
        {
            try
            {
                obj.Date = DateTime.Now;
                var tagList = new List<Tags>();
                foreach (var item in obj.Tags)
                {
                    var tag = new Tags() { Tag = item.Title };
                    var tagRec = new TagReceita()
                    {
                        Receitas = obj,
                        Tags = tag
                    };
                    var tagExist = _unit.Tags.Get(x => x.Tag == item.Title);
                    if (tagExist.Count == 0)
                    {
                        _unit.Tags.Insert(tag);
                        _unit.TagProj.Insert(tagRec);
                    }
                }
                _unit.Receitas.Insert(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            } 
            catch (Exception)
            {

                throw;
            }
            
        }

        // PUT: api/Receitas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Receitas obj)
        {
            try
            {
                var entityExist = _unit.Receitas.EntityExists(obj);
                if (!entityExist) return NotFound();
                _unit.Receitas.Update(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _unit.Receitas.DeleteAsync(id);
                await _unit.CommitAssync();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
