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
    public class DETECTOR_WARNINGController : BaseApiController<DETECTOR_WARNING>
    {
        public DETECTOR_WARNINGController(BaseRepositoryCore<DETECTOR_WARNING> repository) : base(repository)
        {

        }
    }
}
