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
    public class SECONDARY_PACKING_ERRORController : BaseApiController<SECONDARY_PACKING_ERROR>
    {
        public SECONDARY_PACKING_ERRORController(BaseRepositoryCore<SECONDARY_PACKING_ERROR> repository) : base(repository)
        {
        }
    }
}
