using AutoMapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using WayToHair.Core.DTOs;
using WayToHair.Core.Repositories;
using WayToHair.Core.Services;
using WayToHair.Core.UnitOfWorks;
using WayToHair.Core.WayToHairEntites;
using WayToHair.Repository.Repositories;
using WayToHair.Service.Util;

namespace WayToHair.Service.Services
{
    public class ConctactService : Service<Contact>, IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<WayToHairSettings> WayToHairSetting;

        public ConctactService(IGenericRepository<Contact> repoistory, IUnitOfWork unitOfWork, IMapper mapper, IContactRepository contactRepository, IOptions<WayToHairSettings> wayToHairSetting) : base(repoistory, unitOfWork)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            WayToHairSetting = wayToHairSetting;
        }

        public Task SendMail(EmailModel emailModel)
        {
            #region Objects
            var email = new MimeMessage();
            using var smtp = new SmtpClient();
            #endregion

            emailModel.From = WayToHairSetting.Value.EmailSettings.SmtpFromAddress;
            email.From.Add(MailboxAddress.Parse(emailModel.From));
            email.To.Add(MailboxAddress.Parse(emailModel.To));

            email.Subject = email.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailModel.Body };

            #region Send Request
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailModel.From, WayToHairSetting.Value.EmailSettings.SmtpFromPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
            #endregion

            return Task.CompletedTask;

        }
    }
}
