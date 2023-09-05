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
    public class LABELING_RFID_STATUSController : BaseApiController<LABELING_RFID_STATUS>
    {
        public LABELING_RFID_STATUSController(BaseRepositoryCore<LABELING_RFID_STATUS> repository) : base(repository)
        {
        }
    }
}
