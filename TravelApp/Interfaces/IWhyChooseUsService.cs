using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IWhyChooseUsService
    {
        Task<WhyChooseUsInfo> GetInfoAsync();
        Task UpdateInfoAsync(WhyChooseUsInfo updatedInfo);
    }
}
