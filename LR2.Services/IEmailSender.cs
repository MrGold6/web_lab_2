using System.Threading.Tasks;

namespace LR2.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string name, string email, string subject, string message);
    }
}
