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
    public class TagsController : ControllerBase
    {
        private readonly UnitOfWorkTags _unit;

        public TagsController(UnitOfWorkTags unit)
        {
            _unit = unit;
        }

        // POST: api/Tags
        [HttpPost]
        public async Task<ActionResult<Tags>> Post(Tags obj)
        {
            try
            {
                _unit.Tag.Insert(obj);
                await _unit.CommitAssync();
                return Ok(obj);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // DELETE: api/Tags/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _unit.Tag.DeleteAsync(id);
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
