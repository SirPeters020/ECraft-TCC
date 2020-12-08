using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecraft.Api.Data;
using Ecraft.Api.Models;
using Ecraft.Api.Data.Repositories.UnitsOfWork;
using Ecraft.Api.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Ecraft.Api.Models.Join;

namespace Ecraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {

        private readonly UnitOfWorkProjetos _unit;

        public ProjetosController(UnitOfWorkProjetos unit)
        {
            _unit = unit;
        }

        // GET: api/Projetos
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string param)
        {
            return Ok(await _unit.Projetos.GetAsync());
        }

        // GET: api/Projetos/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProjeto(int id)
        {
            var obj = await _unit.GetById(id);

            if(obj == null) return NotFound();

            return Ok(obj);
        }

        // POST: api/Projetos
        [HttpPost]
        public async Task<ActionResult<Projetos>> Post(Projetos obj)
        {
            try
            {
                obj.Date = DateTime.Now;
                var tagList = new List<Tags>();
                foreach(var item in obj.Tags)
                {
                    var tag = new Tags(){Tag = item.Title};
                    var tagProj = new TagProjeto()
                    {
                        Projetos = obj,
                        Tag = tag
                    };
                    var tagExist = _unit.Tag.Get(x => x.Tag == item.Title);
                    if(tagExist.Count == 0)
                    {
                        _unit.Tag.Insert(tag);
                        _unit.TagProj.Insert(tagProj);
                    }
                }
                _unit.Projetos.Insert(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            } 
            catch (Exception)
            {

                throw;
            }
            
        }

        // PUT: api/Projetos/5
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(Projetos obj)
        {
            try
            {
                var entityExist = _unit.Projetos.EntityExists(obj);
                if (!entityExist) return NotFound();
                _unit.Projetos.Update(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Projetos/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _unit.Projetos.DeleteAsync(id);
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
