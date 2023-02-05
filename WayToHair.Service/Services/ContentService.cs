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
    public class ContentService : Service<Content>, IContentService
    {
        private readonly IContentRepository _contenttRepository;
        private readonly IMapper _mapper;

        public ContentService(IGenericRepository<Content> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IContentRepository contactRepository) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _contenttRepository = contactRepository;
        }
    }
}
