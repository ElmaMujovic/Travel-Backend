using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelApp.ImageUploadMethod;
using TravelApp.Contracts.Destinacija.Request;
using TravelApp.Data;
using TravelApp.Interfaces;
using TravelApp.Models;

namespace TravelApp.Services
{
    public class DestinacijaService : IDestinacijaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public DestinacijaService(AppDbContext context, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> createDestinacija(DestinacijaCreateRequest destinacija)
        {
            var dest = mapper.Map<Destinacija>(destinacija);
            dest.ImagePath = await Upload.SaveFile(_hostingEnvironment.ContentRootPath, destinacija.StringPath, "images");
            await _context.Destinacije.AddAsync(dest);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> deleteDestinacija(int id)
        {
            var dest = await _context.Destinacije.FindAsync(id);
            if (dest == null)
            {
                return false;
            }
            _context.Destinacije.Remove(dest);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<Destinacija>> GetAllDestinacija()
        {
            return await _context.Destinacije.ToListAsync();

        }

        public async Task<Destinacija> GetDestinacijaById(int id)
        {
            var dest = await _context.Destinacije.FindAsync(id);
            return dest;
        }

        public async Task<bool> updateDestinacija(DestinacijaUpdateRequest destinacija, int id)
        {
            var destinacijaUpdated = await _context.Destinacije.FindAsync(id);
            mapper.Map(destinacija, destinacijaUpdated);
            destinacijaUpdated.ImagePath = await Upload.SaveFile(_hostingEnvironment.ContentRootPath, destinacija.StringPath, "images");
            _context.Destinacije.Update(destinacijaUpdated);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
        

    }
}
