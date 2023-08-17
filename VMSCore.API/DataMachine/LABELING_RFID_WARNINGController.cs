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
    public class LABELING_RFID_WARNINGController : BaseApiController<LABELING_RFID_WARNING>
    {
        public LABELING_RFID_WARNINGController(BaseRepositoryCore<LABELING_RFID_WARNING> repository) : base(repository)
        {

        }
    }
}
