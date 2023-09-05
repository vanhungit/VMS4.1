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
    public class PRINT_MAKING_STATUSController : BaseApiController<PRINT_MAKING_STATUS>
    {
        public PRINT_MAKING_STATUSController(BaseRepositoryCore<PRINT_MAKING_STATUS> repository) : base(repository)
        {
        }
    }
}
