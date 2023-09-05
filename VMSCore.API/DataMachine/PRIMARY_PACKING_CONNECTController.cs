﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class PRIMARY_PACKING_CONNECTController : BaseApiController<PRIMARY_PACKING_CONNECT>
    {
        public PRIMARY_PACKING_CONNECTController(BaseRepositoryCore<PRIMARY_PACKING_CONNECT> repository) : base(repository)
        {
        }
    }
}
