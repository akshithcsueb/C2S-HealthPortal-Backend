namespace HealthPortalAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string MedicalCondition { get; set; }
        public string SurgicalHistory { get; set; }
        public string Medication { get; set; }
        public string PhotoUrl { get; set; }  // URL of the photo
    }
}
