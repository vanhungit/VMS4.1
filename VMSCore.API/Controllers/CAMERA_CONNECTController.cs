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
    public class CAMERA_CONNECTController : BaseApiController<CAMERA_CONNECT>
    {
        public CAMERA_CONNECTController(BaseRepositoryCore<CAMERA_CONNECT> repository) : base(repository)
        {
        }
    }
}
