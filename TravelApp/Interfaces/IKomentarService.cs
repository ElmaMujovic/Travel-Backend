using Travel.Contracts.Komentar.Request;
using Travel.Models;

namespace Travel.Interfaces
{
    public interface IKomentarService
    {
        Task<bool> AddKomentarAsync(KomentarCreateRequest request);
        Task<bool> DeleteKomentarAsync(int id);
        Task<Komentar> GetKomentarByIdAsync(int id);
        Task<List<Komentar>> GetAllKomentarAsync();
    }
}
