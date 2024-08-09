using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelApp.ImageUploadMethod;
using TravelApp.Contracts.Paketi.Requests;
using TravelApp.Data;
using TravelApp.Interfaces;
using TravelApp.Models;

namespace TravelApp.Services
{
    public class PaketService : IPaketService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public PaketService(AppDbContext context, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> CreatePaket(PaketiCreateRequests paket)
        {
            var pak = _mapper.Map<Paket>(paket);
            if (paket.StringPath != null)
            {
                pak.ImagePath = await Upload.SaveFile(_hostingEnvironment.ContentRootPath, paket.StringPath, "images");
            }
            await _context.Paketi.AddAsync(pak);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> DeletePaket(int id)
        {
            var pak = await _context.Paketi.FindAsync(id);
            if (pak == null)
            {
                return false;
            }
            _context.Paketi.Remove(pak);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<Paket>> GetAllPaketi()
        {
            return await _context.Paketi.ToListAsync();
        }

        public async Task<Paket> GetPaketById(int id)
        {
            var pak = await _context.Paketi.FindAsync(id);
            return pak;
        }

        public async Task<bool> UpdatePaket(PaketiUpdateRequest paket, int id)
        {
            var paketToUpdate = await _context.Paketi.FindAsync(id);
            if (paketToUpdate == null)
            {
                return false;
            }
            _mapper.Map(paket, paketToUpdate);
            if (paket.StringPath != null)
            {
                paketToUpdate.ImagePath = await Upload.SaveFile(_hostingEnvironment.ContentRootPath, paket.StringPath, "images");
            }
            _context.Paketi.Update(paketToUpdate);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
