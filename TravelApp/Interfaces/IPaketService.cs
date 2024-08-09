using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Contracts.Paketi.Requests;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IPaketService
    {
        Task<bool> CreatePaket(PaketiCreateRequests paket);

        Task<bool> UpdatePaket(PaketiUpdateRequest paket, int id);

        Task<bool> DeletePaket(int id);

        Task<List<Paket>> GetAllPaketi();

        Task<Paket> GetPaketById(int id);
    }
}
