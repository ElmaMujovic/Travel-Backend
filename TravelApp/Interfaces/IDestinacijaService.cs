using Travel.Contracts.Destinacija.Request;
using Travel.Models;

namespace Travel.Interfaces
{
    public interface IDestinacijaService
    {

        Task<bool> createDestinacija(DestinacijaCreateRequest destinacija);

        Task<bool> updateDestinacija(DestinacijaUpdateRequest destinacija, int id);

        Task<bool> deleteDestinacija(int id);

        Task<List<Destinacija>> GetAllDestinacija();
        Task<Destinacija> GetDestinacijaById(int id);

    }
}
