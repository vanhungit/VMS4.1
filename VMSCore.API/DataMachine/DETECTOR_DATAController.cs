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
    public class DETECTOR_DATAController : BaseApiController<DETECTOR_DATA>
    {
        public DETECTOR_DATAController(BaseRepositoryCore<DETECTOR_DATA> repository) : base(repository)
        {
        }
    }
}
