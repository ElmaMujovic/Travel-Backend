using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Travel.Contracts.KorisnikDestinacija.Request;
using Travel.Data;
using Travel.Interfaces;
using Travel.Models;

namespace Travel.Services
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
