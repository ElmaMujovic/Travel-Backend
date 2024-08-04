﻿using TravelApp.Contracts.Komentar.Request;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IKomentarService
    {
        Task<bool> AddKomentarAsync(KomentarCreateRequest request);
        Task<bool> DeleteKomentarAsync(int id);
        Task<Komentar> GetKomentarByIdAsync(int id);
        Task<List<Komentar>> GetAllKomentarAsync();
    }
}
