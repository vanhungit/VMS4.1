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
    public class PRINT_MAKING_CONNECTController : BaseApiController<PRINT_MAKING_CONNECT>
    {
        public PRINT_MAKING_CONNECTController(BaseRepositoryCore<PRINT_MAKING_CONNECT> repository) : base(repository)
        {
        }
    }
}
