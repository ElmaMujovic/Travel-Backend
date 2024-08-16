using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Contracts.DestinacijePaketa.Requests;
using TravelApp.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        public async Task<IEnumerable<DestinacijaPaketa>> GetDestinacijeByPaketId(int paketId)
        {
            return await _context.DestinacijaPaketa
                .Where(dp => dp.PaketId == paketId)
                
                .ToListAsync();
        }
        public async Task<IEnumerable<DestinacijaPaketa>> GetDestinacijeByPaketIdnew(int paketId)
        {
            // Dohvatanje svih destinacija za određeni paket
            var destinacije = await _context.DestinacijaPaketa
                .Where(dp => dp.PaketId == paketId)
                .ToListAsync();

            // Filtriranje destinacija koje već imaju dodatu listu
            var destinacijeBezListe = destinacije.Where(d =>
                !_context.Lists.Any(l => l.DestinacijaPaketaId == d.Id)).ToList();

            return destinacijeBezListe;
        }

        public async Task<bool> CreateDestinacijaPaketa(DestinacijaPaketaCreateRequest request)
        {
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

            if (request.Slika != null)
            {
                if (!string.IsNullOrEmpty(destinacijaPaketa.Slika))
                {
                    DeleteFile(destinacijaPaketa.Slika);
                }

                destinacijaPaketa.Slika = SaveFile(request.Slika);
            }

            _context.Entry(destinacijaPaketa).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDestinacijaPaketa(int id)
        {
            var destinacijaPaketa = await _context.DestinacijaPaketa.FindAsync(id);
            if (destinacijaPaketa == null) return false;

            if (!string.IsNullOrEmpty(destinacijaPaketa.Slika))
            {
                DeleteFile(destinacijaPaketa.Slika);
            }

            _context.DestinacijaPaketa.Remove(destinacijaPaketa);
            return await _context.SaveChangesAsync() > 0;
        }

        private string SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(_imageFolderPath, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException("Problem sa čuvanjem fajla.", ex);
            }

            return fileName;  // Vrati samo naziv fajla, ne celu putanju
        }

        private void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (IOException ex)
                {
                    throw new InvalidOperationException("Problem sa brisanjem fajla.", ex);
                }
            }
        }
    }
}
