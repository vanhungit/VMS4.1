﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.Controllers;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;
namespace VMSCore.API.DataDocument
{
    //[Route("api/[controller]")]
    [ApiController]
    public class Device_PROTOCOLController : BaseApiController<Device_PROTOCOL>
    {
        public Device_PROTOCOLController(BaseRepositoryCore<Device_PROTOCOL> repository) : base(repository)
        {
        }
    }
}
