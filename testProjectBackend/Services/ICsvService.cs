using System.Threading.Tasks;

namespace testProjectBackend.Services
{
    public interface ICsvService
    {
        Task ExportData();
    }
}