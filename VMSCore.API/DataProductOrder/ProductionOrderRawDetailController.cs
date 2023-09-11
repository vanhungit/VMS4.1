﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.Controllers;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.API.DataProductOrder
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductionOrderRawDetailController : BaseApiController<ProductionOrderRawDetail>
    {
        public ProductionOrderRawDetailController(BaseRepositoryCore<ProductionOrderRawDetail> repository) : base(repository)
        {
        }
    }
}
