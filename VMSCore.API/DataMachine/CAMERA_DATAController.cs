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
    public class CAMERA_DATAController : BaseApiController<CAMERA_DATA>
    {
        public CAMERA_DATAController(BaseRepositoryCore<CAMERA_DATA> repository) : base(repository)
        {
        }
    }
}
