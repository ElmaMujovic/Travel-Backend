namespace TravelApp.Models
{
    public class WhyChooseUsInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } // "Zašto izabrati nas?"
        public string EconomyPackage { get; set; } // Ekonomični aranžmani
        public string FamilyPackage { get; set; }  // Porodični paketi
        public string LuxuryPackage { get; set; }  // Luksuzni aranžmani
        public string SpecialPackage { get; set; } // Posebni aranžmani
        public string ImageUrl { get; set; }       // URL slike
    }
}
