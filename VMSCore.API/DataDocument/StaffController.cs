﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;
using Microsoft.AspNetCore.Authorization;
using VMSCore.API.Controllers;

namespace VMSCore.API.DataDocument
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class StaffController : BaseApiController<Staff>
    {
        public StaffController(BaseRepositoryCore<Staff> repository) : base(repository)
        {
        }
    }

}
