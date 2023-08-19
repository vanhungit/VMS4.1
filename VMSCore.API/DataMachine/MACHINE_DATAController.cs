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
    public class MACHINE_DATAController : BaseApiController<MACHINE_DATA>
    {
        public MACHINE_DATAController(BaseRepositoryCore<MACHINE_DATA> repository) : base(repository)
        {
        }
    }
}
