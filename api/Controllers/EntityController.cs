using System;
using System.Text.Json;
using System.Threading.Tasks;
using api.Business;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
     public abstract class EntityController<T, U, V> : ControllerBase where T : Entity where U : EntityDB<T> where V : EntityBusiness<T, U>
    {
        private readonly ILogger<EntityController<T, U, V>> _logger;

        protected V business;

        public EntityController(ILogger<EntityController<T, U, V>> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id = 0)
        {
            if (id == 0)
            {
                try
                {
                    return Ok(await business.GetAll());
                }
                catch (System.Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                var getid = await business.GetById(id);
                if (getid == null)
                {
                    return NotFound(new { message = $"Id {id} not found" });
                }
                return Ok(getid);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(T entity)
        {
            try
            {
                var add = await business.Add(entity);
                return Ok(add);
            }
            catch (JsonException)
            {
                return BadRequest(new { message = "Id already exist" });
            }
            catch (System.Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(T entity)
        {
            var upd = await business.Update(entity);
            if (upd == null)
            {
                return BadRequest(new { message = "Id not found or no data to update" });
            }
            return Ok(upd);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var deleted = await business.Remove(id);

            if (deleted == false)
                return NotFound(new { message = $"Id {id} cant be found" });

            return Ok(new { message = "Successfully deleted" });
        }

    }
}
