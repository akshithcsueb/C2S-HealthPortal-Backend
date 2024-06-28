using System;
using System.ComponentModel.DataAnnotations;

namespace HealthPortalAPI.Models.DTOs
{
    public class CreatePatientDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string MedicalCondition { get; set; }

        [Required]
        public string SurgicalHistory { get; set; }

        [Required]
        public string Medication { get; set; }

        [Required]
        public string PhotoUrl { get; set; }
    }
}
