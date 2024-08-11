namespace TravelApp.Contracts.DestinacijePaketa.Requests
{
    public class DestinacijaPaketaUpdateRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public IFormFile Slika { get; set; }
    }
}
