using System.Collections.Generic;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Services.Interfaces
{
    public interface IObjectButtonPermissionService
    {
        List<ObjectButtonPermissionViewModel> GetAssignObjectButtonByAccount(string accountId, string typeId, int type, string moduleType, string groupType);
    }
}
