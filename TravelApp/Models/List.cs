// U TravelApp.Models namespace
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelApp.Data;

namespace TravelApp.Models
{
    public class List
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public string StaraCena { get; set; }

        public string NovaCena { get; set; }

        public bool ImaBazen { get; set; }

        public bool ImaWiFi { get; set; }

        public bool ImaTV { get; set; }

        public bool ImaParking { get; set; }

        public bool ImaPrevoz { get; set; }

        public int BrojZvezdica { get; set; }

        public string Slika { get; set; }

        [ForeignKey("Paket")]
        public int PaketId { get; set; }
        public Paket Paket { get; set; }

        [ForeignKey("DestinacijaPaketa")]
        public int DestinacijaPaketaId { get; set; }
        public DestinacijaPaketa DestinacijaPaketa { get; set; }
    }
}
