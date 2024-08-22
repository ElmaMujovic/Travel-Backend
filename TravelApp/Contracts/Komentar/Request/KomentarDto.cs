namespace TravelApp.Contracts.Komentar.Request
{
    public class KomentarDto
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public string Datum { get; set; }
        public string KorisnikIme { get; set; }
        public string KoristnikPrezime { get; set; }
        public string DestinacijaIme { get; set; }
    }
}
