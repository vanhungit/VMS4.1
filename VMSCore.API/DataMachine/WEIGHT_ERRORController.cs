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
    public class WEIGHT_ERRORController : BaseApiController<WEIGHT_ERROR>
    {
        public WEIGHT_ERRORController(BaseRepositoryCore<WEIGHT_ERROR> repository) : base(repository)
        {
        }
    }
}
