namespace CropMS.Models.DTOs
{
    public class AddFarmerDTO
    {
        public string? FullNames { get; set; }
        public string? IdNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FarmLocation { get; set; }
        //public string? LicenseId { get; set; }
        public string? ProduceExpected { get; set; }
        public bool? PesticideUsage { get; set; } = false;
        public bool? CertifyAsOrganicFarmer { get; set; } = false;
    }
}
