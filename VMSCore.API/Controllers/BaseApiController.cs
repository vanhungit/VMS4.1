using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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
        private readonly IMapper _mapper;
        public BaseApiController(BaseRepositoryCore<TEntity> repository)
        {

            _repository = repository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(MappingProfile).Assembly);
            });
            _mapper = new Mapper(config);
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



        //[HttpPost]
        //public IActionResult Create([FromBody] TEntity entity)
        //{

        //    var createdEntity = _repository.Add(entity);
        //    return CreatedAtAction(nameof(GetById), new { id = GetId(createdEntity) }, createdEntity);
        //}
        [HttpPost]
        public IActionResult Create([FromBody] TEntity entity)
        {
            // Giả sử trong table có cột Code, dòng này lấy giá trị của nó ra
            var type = typeof(TEntity);
            var codeProperty = type.GetProperty("Code");
            string code = codeProperty?.GetValue(entity)?.ToString();

            // Kiểm tra xem có tồn tại chưa
            var existingEntity = _repository.GetByCode(code);

            // Nếu đã tồn tại thì update
            if (existingEntity != null)
            {
                _mapper.Map(entity, existingEntity, type, type);
                _repository.Update(existingEntity);
            }
            else
            {
                // Nếu chưa tồn tại thì thêm mới

                var idProperty = type.GetProperty("Id");
                if (idProperty != null)
                {
                    //idProperty.SetValue(entity, Guid.NewGuid().ToString());


                    if (idProperty.PropertyType == typeof(Guid) || idProperty.PropertyType == typeof(Guid?))
                    {
                        idProperty.SetValue(entity, Guid.NewGuid());
                    }

                    if (idProperty.PropertyType == typeof(string))
                    {
                        idProperty.SetValue(entity, Guid.NewGuid().ToString());
                    }
                }

                entity = _repository.Add(entity);
            }

            return CreatedAtAction(nameof(GetById), new { id = GetId(entity) }, entity);

        }
        [HttpGet]
        public IActionResult GetByDynamicParams([FromQuery] Dictionary<string, string> queryParams)
        {
            var entities = _repository.GetAll();

            foreach (var param in queryParams)
            {
                var propertyName = param.Key;
                var propertyValue = param.Value;

                var property = typeof(TEntity).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (property != null)
                {
                    var parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(TEntity), "e");
                    var propertyExpression = System.Linq.Expressions.Expression.Property(parameterExpression, property);

                    var constantExpression = System.Linq.Expressions.Expression.Constant(Convert.ChangeType(propertyValue, property.PropertyType));

                    var condition = System.Linq.Expressions.Expression.Equal(propertyExpression, constantExpression);

                    var lambdaExpression = System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(condition, parameterExpression);

                    entities = entities.Where(lambdaExpression.Compile()).ToList();
                }
                else
                {
                    // Handle unknown or unsupported properties
                    // You may want to log a warning or return an error response
                    return Ok(new List<TEntity>()); // Return an empty list if property not found
                }
            }

            return Ok(entities);
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
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _repository.GetAll();
            return Ok(entities);
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var entities = _repository.CallAPIPOSTToken("http://tenant1.api.vmspms.vn/connect/token", "desktopvmspms", "1q2w3E*");
        //    return Ok(entities);
        //}
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
