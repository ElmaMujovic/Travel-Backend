using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelApp.Contracts.Komentar.Request;
using TravelApp.Data;
using TravelApp.Interfaces;
using TravelApp.Models;

namespace TravelApp.Services
{
    public class KomentarService : IKomentarService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public KomentarService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }   
        public async Task<bool> AddKomentarAsync(KomentarCreateRequest request)
        {
            var komentar = mapper.Map<Komentar>(request);
            await appDbContext.Komentari.AddAsync(komentar);
            var res = await appDbContext.SaveChangesAsync();
            return res > 0;
           
        }

        public async Task<bool> DeleteKomentarAsync(int id)
        {
           var comm  = await appDbContext.Komentari.FindAsync(id);
           appDbContext.Komentari.Remove(comm);
            var res = await appDbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<Komentar>> GetAllKomentarAsync()
        {
            return await appDbContext.Komentari.ToListAsync();
        }

        public async Task<Komentar> GetKomentarByIdAsync(int id)
        {
            var comm = await appDbContext.Komentari.FindAsync(id);
            return comm;
        }
    }
}
