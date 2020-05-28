namespace cw12.Models
{
    public  class Prescription_Medicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        
        public virtual Prescriptions Prescriptions { get; set; }
        public virtual Medicaments Medicaments { get; set; }
    }
}