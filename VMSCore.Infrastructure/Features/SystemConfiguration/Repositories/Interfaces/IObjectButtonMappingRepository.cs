using System.Collections.Generic;
using VMSCore.EntityModels;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Interfaces
{
    public interface IObjectButtonMappingRepository
    {
        List<ObjectButtonMappingViewModel> GetButton(string objectId);
        List<ObjectButtonMapping> GetButtonByObjectEnity(string objectId);
    }
}
