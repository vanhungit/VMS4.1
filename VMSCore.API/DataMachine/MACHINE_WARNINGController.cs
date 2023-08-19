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
    public class MACHINE_WARNINGController : BaseApiController<MACHINE_WARNING>
    {
        public MACHINE_WARNINGController(BaseRepositoryCore<MACHINE_WARNING> repository) : base(repository)
        {

        }
    }
}
