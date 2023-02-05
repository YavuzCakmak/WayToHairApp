using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayToHair.Core.Repositories;
using WayToHair.Core.Services;
using WayToHair.Core.UnitOfWorks;
using WayToHair.Core.WayToHairEntites;

namespace WayToHair.Service.Services
{
    public class FaqService : Service<Faq>, IFaqService
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IMapper _mapper;

        public FaqService(IGenericRepository<Faq> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IFaqRepository faqRepository) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
        }
    }
}
