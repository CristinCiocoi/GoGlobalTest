using System.Threading.Tasks;

namespace testProjectBackend.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string from, string to, string subject, string html);
    }
}