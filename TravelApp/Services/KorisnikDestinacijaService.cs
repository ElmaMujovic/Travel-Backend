using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelApp.Contracts.KorisnikDestinacija.Request;
using TravelApp.Data;
using TravelApp.Interfaces;
using TravelApp.Models;

namespace TravelApp.Services
{
    public class KorisnikDestinacijaService : IKorisnikDestinacija
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public KorisnikDestinacijaService(AppDbContext korisnikDestinacija, IMapper mapper)
        {
            dbContext = korisnikDestinacija;
            this.mapper = mapper;
        }
        public async Task<bool> AddKorisnikDestinacijaAsync(KorisnikDestinacijaRequest request)
        {
            var destUser = mapper.Map<KorisnikDestinacija>(request);
            await dbContext.KorisnikDestinacije.AddAsync(destUser);
            var res = await dbContext.SaveChangesAsync();
            return res > 0;
            
        }

        public async Task<bool> DeleteKorisnikDestinacijaAsync(int id)
        {
            var destUser = await dbContext.KorisnikDestinacije.FindAsync(id);
            dbContext.KorisnikDestinacije.Remove(destUser);
            var res = await dbContext.SaveChangesAsync();
            return res > 0;
        }

        public Task<List<KorisnikDestinacija>> GetAllKorisnikDestinacijaAsync()
        {
            return dbContext.KorisnikDestinacije.ToListAsync();
        }

        public async Task<KorisnikDestinacija> GetKorisnikDestinacijaByIdAsync(int id)
        {
            var destUser = await dbContext.KorisnikDestinacije.FindAsync(id);
            return destUser;
        }

        public Task<KorisnikDestinacija> UpdateKorisnikDestinacijaAsync(KorisnikDestinacijaUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}
