using HealthPortalAPI.Data;
using HealthPortalAPI.Models;
using HealthPortalAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPortalAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly HealthPortalDbContext _context;

        public PatientService(HealthPortalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> CreatePatientAsync(CreatePatientDto patientDto)
        {
            var newPatient = new Patient
            {
                Name = patientDto.Name,
                Dob = patientDto.Dob,
                Gender = patientDto.Gender,
                EmailId = patientDto.EmailId,
                PhoneNo = patientDto.PhoneNo,
                MedicalCondition = patientDto.MedicalCondition,
                SurgicalHistory = patientDto.SurgicalHistory,
                Medication = patientDto.Medication,
                PhotoUrl = patientDto.PhotoUrl
            };
            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();
            return newPatient;
        }

        public async Task<Patient> UpdatePatientAsync(UpdatePatientDto patientDto)
        {
            var patient = await _context.Patients.FindAsync(patientDto.Id);
            if (patient == null)
            {
                return null;
            }

            patient.Name = patientDto.Name;
            patient.Dob = patientDto.Dob;
            patient.Gender = patientDto.Gender;
            patient.EmailId = patientDto.EmailId;
            patient.PhoneNo = patientDto.PhoneNo;
            patient.MedicalCondition = patientDto.MedicalCondition;
            patient.SurgicalHistory = patientDto.SurgicalHistory;
            patient.Medication = patientDto.Medication;
            patient.PhotoUrl = patientDto.PhotoUrl;

            await _context.SaveChangesAsync();
            return patient;
        }




        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

