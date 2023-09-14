using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMSCore.API.EntityModels.Models;
using VMSCore.Infrastructure.Base.Repositories;
using Microsoft.AspNetCore.Authorization;
using VMSCore.API.Controllers;

namespace VMSCore.API.DataDocument
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class AccountGroupMappingController : BaseApiController<AccountGroupMapping>
    {
        public AccountGroupMappingController(BaseRepositoryCore<AccountGroupMapping> repository) : base(repository)
        {
        }
    }

}
