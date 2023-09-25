using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Newtonsoft.Json.Linq;
using VMSCore.API.EntityModels.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VMSCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
 
    public class SyncController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IMapper _mapper;
        private static readonly Dictionary<string, Type> _entityTypes = new Dictionary<string, Type>
        {

            { "Company", typeof(Company)},
            { "Factory", typeof(Factory) },
            { "WorkShop", typeof(WorkShop) },
            { "Stage", typeof(Stage) },

            { "DeviceGroup", typeof(DeviceGroup) },
            { "TypeDevice", typeof(TypeDevice) },
            { "Device", typeof(Device) },
            { "Device_PROTOCOL", typeof(Device_PROTOCOL) },
            { "ConnectConfig", typeof(ConnectConfig) },
            { "StatusConfig", typeof(StatusConfig) },
            { "ErrorConfig", typeof(ErrorConfig) },
            { "WarningConfig", typeof(WarningConfig) },

            { "Protocol", typeof(Protocol) },
            { "ProtocolParam", typeof(ProtocolParam) },

            { "ProductionOrder", typeof(ProductionOrder) },
            { "ProductionOrderDetail", typeof(ProductionOrderDetail) },
            { "ProductionOrderDetailCode", typeof(ProductionOrderDetailCode) },
            { "ProductionOrderRawDetail", typeof(ProductionOrderRawDetail) },
            { "ProductionOrderDetailMAP", typeof(ProductionOrderDetailMAP) },
            { "ProductionOrderDetailCheck", typeof(ProductionOrderDetailCheck) },

            { "Line", typeof(Line) },
            { "LineDevice", typeof(LineDevice) },

            { "ProductGroup", typeof(ProductGroup) },
            { "ProductType", typeof(ProductType) },
            { "Product", typeof(Product) },
            { "UNIT", typeof(UNIT) },
            { "UNITCONVERT", typeof(UNITCONVERT) },
            { "MaterialProduct", typeof(MaterialProduct) },

            { "Shift", typeof(Shift)},
            { "Staff", typeof(Staff) },
            { "Skills", typeof(Skills) },
            { "StaffSkill", typeof(StaffSkill) },
            { "ShiftStaff", typeof(ShiftStaff) },
            { "Department", typeof(Department) },
            { "DepartmentStaff", typeof(DepartmentStaff) },

            { "Role", typeof(Role) },
            { "RoleDetaill", typeof(RoleDetaill) },
            { "RoleUser", typeof(RoleUser) },
            { "ObjectEntity", typeof(ObjectEntity) },
            { "RoleObjectButtonMapping", typeof(RoleObjectButtonMapping) },

            { "Barcode", typeof(Barcode)},
            { "Button", typeof(Button)},            
            { "Permission", typeof(Permission) },
            { "Contract", typeof(Contract) },
            { "DataSetting", typeof(DataSetting) },
            { "DataSettingCompany", typeof(DataSettingCompany) },
            { "NotificationSystem", typeof(NotificationSystem) },
            { "NotificationConfig", typeof(NotificationConfig) },
            { "NotificationContact", typeof(NotificationContact) },
            { "NotificationLine", typeof(NotificationLine) },
            
            // Thêm các Entity khác muốn hỗ trợ Sync vào đây
            //{ "Account", typeof(Account) },

        };

        public SyncController(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }
        /*
        [HttpPost]
        public IActionResult Sync(string tableName, [FromBody] JArray data)
        {
            if (!_entityTypes.TryGetValue(tableName, out var entityType))
            {
                return BadRequest($"Invalid table name {tableName}");
            }

            var repo = _repositoryFactory.Create(entityType);
            var validationResults = new List<ValidationResult>();

            foreach (var item in data)
            {
                try
                {
                    dynamic entity = item.ToObject(entityType);
                    var existingEntity = repo.GetByCode(entity.Code);//kiểm tra Id có tồn tại
                    // Assuming you have a property called "Id" to check for existing data
                    if (tableName == "ProductionOrder" || tableName == "ProductionOrderDetail" || tableName == "ProductionOrderDetailCode" ||
                        tableName == "ProductionOrderRawDetail" || tableName == "DataSettingCompany")
                    {
                        existingEntity = repo.GetById(entity.Id);

                    }
                    else
                    {
                        existingEntity = repo.GetByCheckID(entity.Id);

                    }
                    var existingEntityCode = repo.GetByCode(entity.Code);//kiểm tra code có tồn tại
                    var isValid = Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true);
                    if (!isValid)
                    {
                        return BadRequest(new
                        {
                            Error = "Validation failed",
                            ValidationErrors = validationResults.Select(vr => new
                            {
                                Message = vr.ErrorMessage,
                                Members = vr.MemberNames
                            })
                        });
                    }

                    if (existingEntity != null)
                    {
                        if (existingEntityCode != null)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, new
                            {

                                Code = 2,
                                Message = "Fail Duplicate Code",
                                ValidationErrors = validationResults.Select(vr => new
                                {
                                    Message = vr.ErrorMessage,
                                    Members = vr.MemberNames
                                })
                            });
                        }
                        else
                        {
                            // If entity exists, update it
                            // Use AutoMapper to map the updated fields to the existing entity
                            _mapper.Map(entity, existingEntity, entityType, entityType);
                            repo.Update(existingEntity);
                        }
                    }
                    else
                    {
                        // If entity does not exist, add it
                        //var modelToAdd = _mapper.Map(entity, entityType, entityType);
                        //if (modelToAdd.Id == null)
                        //{
                        //    modelToAdd.Id = Guid.NewGuid().ToString();
                        //}
                        repo.Add(entity);
                    }
                }
                catch (Exception e)
                {
                    // Log exception and return error response
                    // Log(e);
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to sync {tableName}");
                }
            }

            return Ok(new
            {
                
                Code = 1,
                Message = "Success",
                ValidationErrors = validationResults.Select(vr => new
                {
                    Message = vr.ErrorMessage,
                    Members = vr.MemberNames
                })
            }) ;
        }
        [HttpPost]
        public IActionResult Syncfull(string tableName, bool Flag, [FromBody] JArray data)
        {
            if (!_entityTypes.TryGetValue(tableName, out var entityType))
            {
                return BadRequest($"Invalid table name {tableName}");
            }

            var repo = _repositoryFactory.Create(entityType);
            var validationResults = new List<ValidationResult>();


            foreach (var item in data)
            {
                dynamic entity = item.ToObject(entityType);

                // Assuming you have a property called "Id" to check for existing data
                //var existingEntity = repo.GetByCode(entity.Code);
                var existingEntity = repo.GetByCheckID(entity.Id);
                var existingEntityCode = repo.GetByCode(entity.Code);
                var isValid = Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true);
                if (!isValid)
                {
                    return BadRequest(new
                    {
                        Error = "Validation failed",
                        ValidationErrors = validationResults.Select(vr => new
                        {
                            Message = vr.ErrorMessage,
                            Members = vr.MemberNames
                        })
                    });
                }
                try
                {
                    if (existingEntity != null)
                    {
                        if (existingEntityCode != null)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, new
                            {

                                Code = 2,
                                Message = "Fail Duplicate Code",
                                ValidationErrors = validationResults.Select(vr => new
                                {
                                    Message = vr.ErrorMessage,
                                    Members = vr.MemberNames
                                })
                            });
                        }
                        else
                        {
                            // If entity exists, update it
                            // Use AutoMapper to map the updated fields to the existing entity
                            _mapper.Map(entity, existingEntity, entityType, entityType);
                            if (Flag)//Flag = true là xóa
                            {
                                repo.Delete(existingEntity);
                            }
                            else
                            {
                                repo.Update(existingEntity);

                            }
                        }
                    }
                    else
                    {
                        // If entity does not exist, add it
                        //var modelToAdd = _mapper.Map(entity, entityType, entityType);
                        ////if (modelToAdd.Id == null)
                        ////{
                        ////    modelToAdd.Id = Guid.NewGuid().ToString();
                        ////}
                        //repo.Add(modelToAdd);
                        repo.Add(entity);
                    }
                }
                catch (Exception e)
                {
                    // Log exception and return error response
                    // Log(e);
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to sync {tableName}");
                }
            }

            return Ok(new
            {

                Code = 1,
                Message = "Success",
                ValidationErrors = validationResults.Select(vr => new
                {
                    Message = vr.ErrorMessage,
                    Members = vr.MemberNames
                })
            });
        }*/
        [HttpPost]
        public IActionResult SyncfullCheckCode(string tableName, bool Flag, [FromBody] JArray data)
        {
            if (!_entityTypes.TryGetValue(tableName, out var entityType))
            {
                return BadRequest($"Invalid table name {tableName}");
            }

            var repo = _repositoryFactory.Create(entityType);
            var validationResults = new List<ValidationResult>();


            foreach (var item in data)
            {
                dynamic entity = item.ToObject(entityType);

                // Assuming you have a property called "Id" to check for existing data
                //var existingEntity = repo.GetByCode(entity.Code);
                
                var existingEntityCode = repo.GetByCode(entity.Code);
                var isValid = Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true);
                if (!isValid)
                {
                    return BadRequest(new
                    {
                        Error = "Validation failed",
                        ValidationErrors = validationResults.Select(vr => new
                        {
                            Message = vr.ErrorMessage,
                            Members = vr.MemberNames
                        })
                    });
                }
                try
                {
                    if (existingEntityCode != null)
                    {
                        
                        _mapper.Map(entity, existingEntityCode, entityType, entityType);
                        if (Flag)//Flag = true là xóa
                        {
                            repo.Delete(existingEntityCode);
                        }
                        else
                        {
                            repo.Update(existingEntityCode);

                        }
                    }
                    else if(Flag)
                    {
                        ;
                    }    
                    else
                    {
                        // If entity exists, update it
                        // Use AutoMapper to map the updated fields to the existing entity
                        var modelToAdd = _mapper.Map(entity, entityType, entityType);
                        if (modelToAdd.Id == null)
                        {
                            modelToAdd.Id = Guid.NewGuid();
                        }
                        //var idProperty = entityType.GetProperty("Id");
                        //if (idProperty != null)
                        //{
                        //    //idProperty.SetValue(entity, Guid.NewGuid().ToString());


                        //    if (idProperty.PropertyType == typeof(Guid) || idProperty.PropertyType == typeof(Guid?))
                        //    {
                        //        idProperty.SetValue(entity, Guid.NewGuid());
                        //    }

                        //    if (idProperty.PropertyType == typeof(string))
                        //    {
                        //        idProperty.SetValue(entity, Guid.NewGuid().ToString());
                        //    }
                        //}
                        //modelToAdd.Id = Guid.NewGuid();
                        repo.Add(modelToAdd);

                    }
                    
                }
                catch (Exception e)
                {
                    // Log exception and return error response
                    // Log(e);
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to sync {tableName}");
                }
            }

            return Ok(new
            {

                Code = 1,
                Message = "Success",
                ValidationErrors = validationResults.Select(vr => new
                {
                    Message = vr.ErrorMessage,
                    Members = vr.MemberNames
                })
            });
        }

    }
}
