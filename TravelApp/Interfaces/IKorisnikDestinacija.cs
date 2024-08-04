using TravelApp.Contracts.KorisnikDestinacija.Request;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IKorisnikDestinacija
    {
        Task<bool> AddKorisnikDestinacijaAsync(KorisnikDestinacijaRequest request);
        Task<KorisnikDestinacija> GetKorisnikDestinacijaByIdAsync(int id);
        Task<List<KorisnikDestinacija>> GetAllKorisnikDestinacijaAsync();
        Task<KorisnikDestinacija> UpdateKorisnikDestinacijaAsync(KorisnikDestinacijaUpdate request);
        Task<bool> DeleteKorisnikDestinacijaAsync(int id);
    }
}
