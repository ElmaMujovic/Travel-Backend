namespace TravelApp.Contracts.Paketi.Requests
{
    public class PaketiUpdateRequest
    {
        public string Naziv { get; set; }
        public IFormFile StringPath { get; set; }

        public double Tag { get; set; }
    }
}
