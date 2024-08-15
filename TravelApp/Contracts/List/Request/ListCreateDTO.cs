using System.ComponentModel.DataAnnotations;

namespace TravelApp.Contracts.List.Request
{
    public class ListCreateDTO
    {
        //public int Id { get; set; } // Može se ignorisati pri kreiranju ako je nepotrebno

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

        [Required]
        public IFormFile Slika { get; set; }

        [Required]
        public int PaketId { get; set; } // Id paketa kojem lista pripada

        [Required]
        public int DestinacijaPaketaId { get; set; } // Id destinacije kojoj lista pripada
    }
}
