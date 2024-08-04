namespace Travel.Contracts.Destinacija.Request
{
    public class DestinacijaUpdateRequest
    {
        public string Naziv { get; set; }
        public IFormFile StringPath { get; set; }

        public double Cena { get; set; }    
    }
}
