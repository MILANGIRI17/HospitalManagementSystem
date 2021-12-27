using System.Collections.ObjectModel;

namespace Hospital.Models
{
    public class Service
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int TreatmentId { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
