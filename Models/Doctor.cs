    using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string Speciality { get; set; }
        public string SurgerySuccessRate { get; set; }
        public bool Availability { get; set; }
        public string Education { get; set; }
    }
}
