using HealthPortalAPI.Models;
using HealthPortalAPI.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPortalAPI.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<Patient> CreatePatientAsync(CreatePatientDto patientDto);
        Task<Patient> UpdatePatientAsync(UpdatePatientDto patientDto);
        Task<bool> DeletePatientAsync(int id);
    }
}
