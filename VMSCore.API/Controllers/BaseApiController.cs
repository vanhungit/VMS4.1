using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using VMSCore.API.DataValidation;
using VMSCore.API.EntityModels.Interfaces;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController<TEntity> : ControllerBase where TEntity : class

    {
        private readonly BaseRepositoryCore<TEntity> _repository;

        public BaseApiController(BaseRepositoryCore<TEntity> repository)
        {
            _repository = repository;
        }
      
        // Helper method to get the Id of an entity.
        protected virtual string GetId(TEntity entity)
        {
            var type = typeof(TEntity);
            string typeName = type.Name; // Get the name of the type
            string idPropertyName = typeName + "Id"; // Construct the ID property name

            var prop = type.GetProperty("Id") ?? type.GetProperty(idPropertyName);
            return prop?.GetValue(entity)?.ToString();
        }



        [HttpPost]
        public IActionResult Create([FromBody] TEntity entity)
        {
            var createdEntity = _repository.Add(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetId(createdEntity) }, createdEntity);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var entity = _repository.GetOneByCondition(e => GetId(e) == id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        [HttpGet("{Code}")]
        public IActionResult GetByCode(string Code)
        {
            var entity = _repository.GetByCode(Code);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var entities = _repository.GetAll();
        //    return Ok(entities);
        //}
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _repository.CallAPIPOSTToken("http://tenant1.api.vmspms.vn/connect/token", "desktopvmspms", "1q2w3E*");
            return Ok(entities);
        }
        [HttpGet]
        public IActionResult GetAllByToken()
        {
            var entities = _repository.CallAPIPOSTToken("http://tenant1.api.vmspms.vn/connect/token", "desktopvmspms", "1q2w3E*");
            return Ok(entities);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TEntity entity)
        {
            if (id != GetId(entity))
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetOneByCondition(e => GetId(e) == id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var entity = _repository.GetOneByCondition(e => GetId(e) == id);
            if (entity == null)
            {
                return NotFound();
            }

            _repository.Delete(entity);

            return NoContent();
        }
    }
}
