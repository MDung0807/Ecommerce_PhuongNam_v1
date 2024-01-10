using Ecommerce_PhuongNam_v1.Application.Common.MailKet.DTO.Request;

namespace Ecommerce_PhuongNam_v1.Application.Common.MailKet.Service;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
    Task SendEmailsAsync(List<MailRequest> mailRequests);
}