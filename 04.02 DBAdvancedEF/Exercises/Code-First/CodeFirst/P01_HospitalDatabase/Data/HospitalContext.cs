using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientEntity(modelBuilder);
            VisitationEntity(modelBuilder);
            DiagnoseEntity(modelBuilder);
            MedicamentEntity(modelBuilder);
            PatientMedicamentEntity(modelBuilder);
            DoctorEntity(modelBuilder);
        }

        private void DoctorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(doc => doc.DoctorId);

            modelBuilder.Entity<Doctor>().HasMany(doc => doc.Visitations).WithOne(vis => vis.Doctor);

            modelBuilder.Entity<Doctor>().Property(doc => doc.Name).HasMaxLength(100).IsUnicode().IsRequired();

            modelBuilder.Entity<Doctor>().Property(doc => doc.Specialty).HasMaxLength(100).IsUnicode();
        }

        private void PatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>().HasKey(pm => new {pm.PatientId, pm.MedicamentId});

            modelBuilder.Entity<PatientMedicament>().HasOne(pm => pm.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder.Entity<PatientMedicament>().HasOne(pm => pm.Medicament).WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);

        }

        private void MedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>().HasKey(m => m.MedicamentId);

            modelBuilder.Entity<Medicament>().Property(m => m.Name).HasMaxLength(50).IsUnicode().IsRequired();
        }

        private void DiagnoseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>().HasKey(d => d.DiagnoseId);

            modelBuilder.Entity<Diagnose>().Property(d => d.Name).HasMaxLength(50).IsUnicode().IsRequired();

            modelBuilder.Entity<Diagnose>().Property(d => d.Comments).HasMaxLength(250).IsUnicode();
        }

        private void VisitationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>().HasKey(p => p.VisitationId);

            modelBuilder.Entity<Visitation>().Property(v => v.Comments).HasMaxLength(250);
        }

        private void PatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientId);

            modelBuilder.Entity<Patient>().HasMany(p => p.Visitations).WithOne(p => p.Patient);

            modelBuilder.Entity<Patient>().HasMany(p => p.Prescriptions).WithOne(p => p.Patient);

            modelBuilder.Entity<Patient>().HasMany(p => p.Diagnoses).WithOne(p => p.Patient);

            modelBuilder.Entity<Patient>().Property(p => p.FirstName).HasMaxLength(50).IsUnicode().IsRequired();

            modelBuilder.Entity<Patient>().Property(p => p.LastName).HasMaxLength(50).IsUnicode().IsRequired();

            modelBuilder.Entity<Patient>().Property(p => p.Address).HasMaxLength(250).IsUnicode().IsRequired();

            modelBuilder.Entity<Patient>().Property(p => p.Email).HasMaxLength(80).IsUnicode(false);
        }
    }
}