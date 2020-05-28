using System;
using System.Collections.Generic;

namespace cw12.Models
{
    public class Prescriptions
    {
        public Prescriptions()
        {
            Prescription_Medicaments = new HashSet<Prescription_Medicament>();
        }

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Doctors Doctor { get; set; }

        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}