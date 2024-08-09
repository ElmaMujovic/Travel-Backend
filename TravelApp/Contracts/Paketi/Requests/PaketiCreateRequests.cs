using Microsoft.AspNetCore.Http;

namespace TravelApp.Contracts.Paketi.Requests
{
    public class PaketiCreateRequests
    {
        public string Naziv { get; set; } 
        public string Opis { get; set; } 
        public IFormFile StringPath { get; set; } 
        public double Tag { get; set; } 
    }
}
