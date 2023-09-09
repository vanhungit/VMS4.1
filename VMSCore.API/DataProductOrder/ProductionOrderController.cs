using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;
using Microsoft.AspNetCore.Authorization;
using VMSCore.API.Controllers;

namespace VMSCore.API.DataProductOrder
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ProductionOrderController : BaseApiController<ProductionOrder>
    {
        public ProductionOrderController(BaseRepositoryCore<ProductionOrder> repository) : base(repository)
        {
        }
    }

}
