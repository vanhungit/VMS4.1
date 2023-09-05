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
    public class DETECTOR_CONNECTController : BaseApiController<DETECTOR_CONNECT>
    {
        public DETECTOR_CONNECTController(BaseRepositoryCore<DETECTOR_CONNECT> repository) : base(repository)
        {
        }
    }
}
