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
    public class WorkShopController : BaseApiController<WorkShop>
    {
        public WorkShopController(BaseRepositoryCore<WorkShop> repository) : base(repository)
        {
        }
    }

}
