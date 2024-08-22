using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<Korisnik> _userManager;
        public KorisnikDestinacijaService(AppDbContext korisnikDestinacija, IMapper mapper, UserManager<Korisnik> userManager)
        {
            dbContext = korisnikDestinacija;
            this.mapper = mapper;
            _userManager = userManager;

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
        public async Task<bool> AddKorisnikDestinacijaFavorites(KorisnikDestinacijaRequest request)
        {
            var destUser = mapper.Map<KorisnikDestinacija>(request);
            await dbContext.KorisnikDestinacije.AddAsync(destUser);
            var res = await dbContext.SaveChangesAsync();
            return res > 0;
        }
        public async Task<bool> AddKorisnikDestinacijaFavoritesAsync(int korisnikId, int destinacijaId)
        {
            // Pretpostavimo da imaš userManager i destinacijaService koji obavljaju posao dobijanja korisnika i destinacije
            var korisnik = await _userManager.FindByIdAsync(korisnikId.ToString());
            var destinacija = await dbContext.Destinacije.FindAsync(destinacijaId);

            if (korisnik == null || destinacija == null)
            {
                return false;
            }

            var korisnikDestinacija = new KorisnikDestinacija
            {
                KorisnikId = korisnik.Id,
                Korisnik = korisnik,
                DestinacijaId = destinacija.Id,
                Destinacija = destinacija
            };

            await dbContext.KorisnikDestinacije.AddAsync(korisnikDestinacija);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> RemoveKorisnikDestinacijaAsync(int destinacijaId)
        {
            var destUser = await dbContext.KorisnikDestinacije
                .Where(kd =>  kd.DestinacijaId == destinacijaId).FirstOrDefaultAsync();

            if (destUser == null)
            {
                return false;
            }

            dbContext.KorisnikDestinacije.Remove(destUser);
            var res = await dbContext.SaveChangesAsync();
            if (res <= 0)
            {
                Console.WriteLine("Brisanje lajka nije uspelo");
            }
            return res > 0;
        }
        
        public async Task<IEnumerable<Destinacija>> GetLajkovaneDestinacijeAsync(int korisnikId)
        {
            return await dbContext.KorisnikDestinacije

                .Where(kd => kd.KorisnikId == korisnikId)
                .Include(kd => kd.Destinacija) 
                .Select(kd => kd.Destinacija)
                .ToListAsync();
        }






    }
}
