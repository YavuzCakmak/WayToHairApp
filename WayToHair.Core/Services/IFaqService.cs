using WayToHair.Core.DTOs;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.Core.Services
{
    public interface IFaqService : IService<Faq>
    {
        Task<List<FaqDto>> GetAllFaqAndMeaning(byte languageType);
    }
}
