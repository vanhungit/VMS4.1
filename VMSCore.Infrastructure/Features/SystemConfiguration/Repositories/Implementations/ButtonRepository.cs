using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Interfaces;
using VMSCore.ViewModels.SystemConfiguration;
namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations
{
    public class ButtonRepository : BaseRepository<Button>, IButtonRepository
    {
        public List<ButtonViewModel> Search(string name)
        {
            var hasName = string.IsNullOrWhiteSpace(name);
            var buttons = (from p in _context.Button
                           orderby p.Name
                           where hasName == true || p.Name.Contains(name) || p.ButtonNameEn.Contains(name)
                           select new ButtonViewModel()
                           {
                               ButtonId = p.Id,
                               ButtonName = p.Name,
                               ButtonNameEn = p.ButtonNameEn,
                               Active = p.Active,
                               Description = p.Description
                           }).ToList();
            ;

            return buttons;
        }


    }
}
