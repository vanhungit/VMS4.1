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
    public class RoleUserController : BaseApiController<RoleUser>
    {
        public RoleUserController(BaseRepositoryCore<RoleUser> repository) : base(repository)
        {
        }
    }
}
