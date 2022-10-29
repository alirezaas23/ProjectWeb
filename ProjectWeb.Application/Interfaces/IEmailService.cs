using System.Threading.Tasks;

namespace ProjectWeb.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string to, string subject, string body);
    }
}
