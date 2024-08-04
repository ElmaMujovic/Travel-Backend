namespace Travel.Contracts.Destinacija.Request
{
    public class DestinacijaCreateRequest
    {
     
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public IFormFile StringPath { get; set; }

        public double Cena { get; set; }
    }
}
