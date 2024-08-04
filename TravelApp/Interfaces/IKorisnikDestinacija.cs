using Travel.Contracts.KorisnikDestinacija.Request;
using Travel.Models;

namespace Travel.Interfaces
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
