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
    public class SECONDARY_PACKING_WARNINGController : BaseApiController<SECONDARY_PACKING_WARNING>
    {
        public SECONDARY_PACKING_WARNINGController(BaseRepositoryCore<SECONDARY_PACKING_WARNING> repository) : base(repository)
        {

        }
    }
}
