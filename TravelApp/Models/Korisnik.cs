using Microsoft.AspNetCore.Identity;

namespace Travel.Models
{
    public class Korisnik : IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        
        public int Godina { get; set; }
        public string Grad { get; set; }

        public string ImagePath { get; set; }

        public List<KorisnikDestinacija> KorisnikDestinacije { get; set;}
        public List<Komentar> Komentari { get; set; }


    }

}
