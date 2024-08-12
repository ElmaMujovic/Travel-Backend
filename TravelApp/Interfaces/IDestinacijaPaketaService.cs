using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Contracts.DestinacijePaketa.Requests;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IDestinacijaPaketaService
    {
        Task<IEnumerable<DestinacijaPaketa>> GetAllDestinacijePaketa();
        Task<DestinacijaPaketa> GetDestinacijaPaketaById(int id);
        Task<bool> CreateDestinacijaPaketa(DestinacijaPaketaCreateRequest request);
        Task<bool> UpdateDestinacijaPaketa(DestinacijaPaketaUpdateRequest request, int id);
        Task<bool> DeleteDestinacijaPaketa(int id);
        Task<IEnumerable<DestinacijaPaketa>> GetDestinacijeByPaketId(int paketId); // Dodato
    }
}
