using System.ComponentModel.DataAnnotations;

namespace TravelApp.Contracts.List.Request
{
    public class ListUpdateDTO
    {
        [Required]
        public int Id { get; set; } // Id liste koja se ažurira
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

        public IFormFile Slika { get; set; } // Slika se prenosi kao fajl

        [Required]
        public int PaketId { get; set; } // Id paketa kojem lista pripada

        [Required]
        public int DestinacijaPaketaId { get; set; } // Id destinacije kojoj lista pripada
    }
}

