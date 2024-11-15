﻿namespace VeterinaryMS.Models.DTOs
{
    public class AddVetDTO
    {
        public string? FullNames { get; set; }
        public string? IdNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? PrimaryLocation { get; set; }
        public string? LicenseId { get; set; }
        public string? Specialty { get; set; }
        public string? WorkingHours { get; set; }
        public string? WorkingDays { get; set; }
        public bool? AcceptsInpatient { get; set; } = false;
    }
}