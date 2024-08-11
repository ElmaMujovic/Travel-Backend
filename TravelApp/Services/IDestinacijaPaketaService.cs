using System.IO;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Contracts.DestinacijePaketa.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelApp.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TravelApp.Services
{
    public class DestinacijaPaketaService : IDestinacijaPaketaService
    {
        private readonly AppDbContext _context;
        private readonly string _imageFolderPath;

        public DestinacijaPaketaService(AppDbContext context, string imageFolderPath)
        {
            _context = context;
            _imageFolderPath = imageFolderPath;
        }

        public async Task<IEnumerable<DestinacijaPaketa>> GetAllDestinacijePaketa()
        {
            return await _context.DestinacijaPaketa.ToListAsync();
        }

        public async Task<DestinacijaPaketa> GetDestinacijaPaketaById(int id)
        {
            return await _context.DestinacijaPaketa.FindAsync(id);
        }

        public async Task<bool> CreateDestinacijaPaketa(DestinacijaPaketaCreateRequest request)
        {
            // Čuvanje slike i dobijanje putanje
            var imagePath = SaveFile(request.Slika);

            var destinacijaPaketa = new DestinacijaPaketa
            {
                Naziv = request.Naziv,
                Opis = request.Opis,
                Slika = imagePath,
                PaketId = request.PaketId
            };
            _context.DestinacijaPaketa.Add(destinacijaPaketa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDestinacijaPaketa(DestinacijaPaketaUpdateRequest request, int id)
        {
            var destinacijaPaketa = await _context.DestinacijaPaketa.FindAsync(id);
            if (destinacijaPaketa == null) return false;

            destinacijaPaketa.Naziv = request.Naziv;
            destinacijaPaketa.Opis = request.Opis;

            // Ako je slika nova, sačuvaj je i ažuriraj putanju
            if (request.Slika != null)
            {
                destinacijaPaketa.Slika = SaveFile(request.Slika);
            }

            _context.Entry(destinacijaPaketa).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDestinacijaPaketa(int id)
        {
            var destinacijaPaketa = await _context.DestinacijaPaketa.FindAsync(id);
            if (destinacijaPaketa == null) return false;

            _context.DestinacijaPaketa.Remove(destinacijaPaketa);
            return await _context.SaveChangesAsync() > 0;
        }

        private string SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            // Kreiraj putanju do direktorijuma gde će se fajl čuvati
            var filePath = Path.Combine(_imageFolderPath, file.FileName);

            // Čuvanje fajla na fizičkom disku
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Vraća putanju do fajla
            return filePath;
        }
    }
}
