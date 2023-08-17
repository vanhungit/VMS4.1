using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButtonController : BaseApiController<Button>
    {
        public ButtonController(BaseRepositoryCore<Button> repository) : base(repository)
        {
        }
    }

}
