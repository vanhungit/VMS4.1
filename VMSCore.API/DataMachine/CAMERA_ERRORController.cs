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
    public class CAMERA_ERRORController : BaseApiController<CAMERA_ERROR>
    {
        public CAMERA_ERRORController(BaseRepositoryCore<CAMERA_ERROR> repository) : base(repository)
        {
        }
    }
}
