using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cw12.Models
{
    public partial class PrescriptionDbContext : DbContext
    {
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Medicaments> Medicaments { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }




        public PrescriptionDbContext(DbContextOptions options)
        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });

                entity.HasIndex(e => e.IdPrescription);

                entity.HasOne(e => e.Medicaments)
                    .WithMany(e => e.Prescription_Medicaments)
                    .HasForeignKey(e => e.IdMedicament);

                entity.HasOne(e => e.Prescriptions)
                    .WithMany(e => e.Prescription_Medicaments)
                    .HasForeignKey(e => e.IdPrescription);
            });

            modelBuilder.Entity<Prescriptions>(entity =>
            {
                entity.HasIndex(e => e.IdDoctor);

                entity.HasIndex(e => e.IdPatient);

                entity.HasOne(e => e.Doctor)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.IdDoctor);

                entity.HasOne(e => e.Patient)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.IdPatient);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}