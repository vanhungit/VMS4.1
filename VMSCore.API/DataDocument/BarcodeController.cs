using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.Controllers;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.API.DataDocument
{
    //[Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : BaseApiController<Barcode>
    {
        public BarcodeController(BaseRepositoryCore<Barcode> repository) : base(repository)
        {
        }
    }
}
