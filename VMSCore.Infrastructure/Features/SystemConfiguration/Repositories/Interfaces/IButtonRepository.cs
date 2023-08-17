using System.Collections.Generic;
using VMSCore.ViewModels.SystemConfiguration;
namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Interfaces
{
    public interface IButtonRepository
    {
        List<ButtonViewModel> Search(string name);
    }
}
