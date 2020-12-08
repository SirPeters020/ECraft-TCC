using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecraft.Api.Data.Repositories.UnitsOfWork;
using Ecraft.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecraft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostasController : ControllerBase
    {

        private readonly UnitOfWorkPerguntas _unit;

        public RespostasController(UnitOfWorkPerguntas unit)
        {
            _unit = unit;
        }

        // POST: api/Respostas
        [HttpPost]
        public async Task<ActionResult<Respostas>> Post(Respostas obj)
        {
            try
            {
                obj.Data = DateTime.Now;
                _unit.Respostas.Insert(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // PUT: api/Respostas/5
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(Respostas obj)
        {
            try
            {
                var entityExist = _unit.Respostas.EntityExists(obj);
                if (!entityExist) return NotFound();
                _unit.Respostas.Update(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Respostas/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _unit.Respostas.DeleteAsync(id);
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
