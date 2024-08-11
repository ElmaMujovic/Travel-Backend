namespace TravelApp.Contracts.DestinacijePaketa.Requests
{
    public class DestinacijaPaketaCreateRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public IFormFile Slika { get; set; }
        public int PaketId { get; set; }
    }
}
