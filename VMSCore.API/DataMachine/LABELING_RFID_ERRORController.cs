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
    public class LABELING_RFID_ERRORController : BaseApiController<LABELING_RFID_ERROR>
    {
        public LABELING_RFID_ERRORController(BaseRepositoryCore<LABELING_RFID_ERROR> repository) : base(repository)
        {
        }
    }
}
