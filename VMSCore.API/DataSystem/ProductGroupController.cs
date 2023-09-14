using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.Controllers;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;
namespace VMSCore.API.DataSystem
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : BaseApiController<ProductGroup>
    {
        public ProductGroupController(BaseRepositoryCore<ProductGroup> repository) : base(repository)
        {
        }
    }
}
