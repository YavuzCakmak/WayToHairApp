using WayToHair.Core.DTOs;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.Core.Services
{
    public interface IContentService : IService<Content>
    {
        Task<ContentDto> GetSidebarAndContent(byte sidebarId, byte languageType);
        Task<List<FaqDto>> GetAllFaqAndMeaning(byte languageType);

    }
}
