using TravelApp.Data; // Uvezite AppDbContext
using TravelApp.Interfaces;
using TravelApp.Models;
using Microsoft.EntityFrameworkCore; // Uverite se da je ovo uvezeno

namespace TravelApp.Services
{
    public class WhyChooseUsService : IWhyChooseUsService
    {
        private readonly AppDbContext _context;

        public WhyChooseUsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<WhyChooseUsInfo> GetInfoAsync()
        {
            return await _context.WhyChooseUsInfos.FirstOrDefaultAsync();
        }

        public async Task UpdateInfoAsync(WhyChooseUsInfo updatedInfo)
        {
            // Pretpostavljamo da postoji samo jedan zapis
            var info = await _context.WhyChooseUsInfos.FirstOrDefaultAsync();
            if (info == null)
                throw new Exception("Info not found");

            info.Title = updatedInfo.Title;
            info.EconomyPackage = updatedInfo.EconomyPackage;
            info.FamilyPackage = updatedInfo.FamilyPackage;
            info.LuxuryPackage = updatedInfo.LuxuryPackage;
            info.SpecialPackage = updatedInfo.SpecialPackage;
            info.ImageUrl = updatedInfo.ImageUrl;

            await _context.SaveChangesAsync();
        }
    }
}
