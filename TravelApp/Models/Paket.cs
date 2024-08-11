using System.ComponentModel.DataAnnotations;
using TravelApp.Models;
using System.Collections.Generic;
using TravelApp.Data;


namespace TravelApp.Models
{
    public class Paket
    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Tag { get; set; } 
        public string ImagePath { get; set; } // Pretpostavljamo da je ovo za sliku
        public ICollection<DestinacijaPaketa> DestinacijePaketa { get; set; }  // Ispravna veza sa DestinacijaPaketa

    }
}
