using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : BaseApiController<Staff>
    {
        public StaffController(BaseRepositoryCore<Staff> repository) : base(repository)
        {
        }
    }

}
