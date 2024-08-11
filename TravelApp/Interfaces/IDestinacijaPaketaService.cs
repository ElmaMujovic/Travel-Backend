using TravelApp.Contracts.DestinacijePaketa.Requests;
using TravelApp.Data;

namespace TravelApp.Interfaces
{
    public interface IDestinacijaPaketaService
    {
        Task<IEnumerable<DestinacijaPaketa>> GetAllDestinacijePaketa();
        Task<DestinacijaPaketa> GetDestinacijaPaketaById(int id);
        Task<bool> CreateDestinacijaPaketa(DestinacijaPaketaCreateRequest request);
        Task<bool> UpdateDestinacijaPaketa(DestinacijaPaketaUpdateRequest request, int id);
        Task<bool> DeleteDestinacijaPaketa(int id);
    }
}
