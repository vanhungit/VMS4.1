using Microsoft.AspNetCore.Mvc;
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
    public class WEIGHT_WARNINGController : BaseApiController<WEIGHT_WARNING>
    {
        public WEIGHT_WARNINGController(BaseRepositoryCore<WEIGHT_WARNING> repository) : base(repository)
        {

        }
    }
}
