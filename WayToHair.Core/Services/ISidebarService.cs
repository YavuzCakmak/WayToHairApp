using WayToHair.Core.DTOs;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.Core.Services
{
    public interface ISidebarService : IService<Sidebar>
    {
        Task<List<SidebarResponseDto>> GetAllSidebarAndMeaning(byte languageType);
    }
}
