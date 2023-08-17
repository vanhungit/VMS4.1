using System.Collections.Generic;
using System.Data;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Services.Interfaces
{
    public interface IStaffPermissionService
    {
        StaffPermissionViewModel GetPermissionByAccountId(string accountId);
    }
}
