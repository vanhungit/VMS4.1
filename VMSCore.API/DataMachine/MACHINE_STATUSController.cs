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
    public class MACHINE_STATUSController : BaseApiController<MACHINE_STATUS>
    {
        public MACHINE_STATUSController(BaseRepositoryCore<MACHINE_STATUS> repository) : base(repository)
        {
        }
    }
}
