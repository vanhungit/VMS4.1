﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.Controllers;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;
namespace VMSCore.API.DataSystem
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StatusConfigController : BaseApiController<StatusConfig>
    {
        public StatusConfigController(BaseRepositoryCore<StatusConfig> repository) : base(repository)
        {
        }
    }
}
