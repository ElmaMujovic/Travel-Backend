using TravelApp.Contracts.Komentar.Request;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IKomentarService
    {
        Task<bool> AddKomentarAsync(KomentarCreateRequest request);
        Task<bool> DeleteKomentarAsync(int id);
        Task<List<KomentarDto>> GetKomentarByDestinacijaIdAsync(int id);
        Task<List<Komentar>> GetAllKomentarAsync();
    }
}
