using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Contracts.List.Request;
using TravelApp.Models;

namespace TravelApp.Interfaces
{
    public interface IListService
    {
        Task<IEnumerable<List>> GetAllListsAsync();
        Task<List> GetListByIdAsync(int id);
        Task<List> CreateListAsync(ListCreateDTO listCreateDTO);
        Task UpdateListAsync(int id, ListUpdateDTO listUpdateDTO);
        Task DeleteListAsync(int id);
    }
}
