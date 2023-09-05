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
    public class PRIMARY_PACKING_WARNINGController : BaseApiController<PRIMARY_PACKING_WARNING>
    {
        public PRIMARY_PACKING_WARNINGController(BaseRepositoryCore<PRIMARY_PACKING_WARNING> repository) : base(repository)
        {

        }
    }
}
