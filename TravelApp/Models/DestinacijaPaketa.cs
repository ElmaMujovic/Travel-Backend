using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelApp.Models;
using TravelApp.Data;


namespace TravelApp.Data
{
    public class DestinacijaPaketa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public string Slika { get; set; }
        

        [ForeignKey("Paket")]
        public int PaketId { get; set; }
        public Paket Paket { get; set; }
    }
}
