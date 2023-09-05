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
    public class PRIMARY_PACKING_STATUSController : BaseApiController<PRIMARY_PACKING_STATUS>
    {
        public PRIMARY_PACKING_STATUSController(BaseRepositoryCore<PRIMARY_PACKING_STATUS> repository) : base(repository)
        {
        }
    }
}
