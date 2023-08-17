using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DETECTOR_ERRORController : BaseApiController<DETECTOR_ERROR>
    {
        public DETECTOR_ERRORController(BaseRepositoryCore<DETECTOR_ERROR> repository) : base(repository)
        {
        }
    }
}
