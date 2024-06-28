using HealthPortalAPI.Models;
using HealthPortalAPI.Models.DTOs;
using HealthPortalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HealthPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(IPatientService patientService, ILogger<PatientsController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            _logger.LogInformation("GetPatients called");
            var patients = await _patientService.GetPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            _logger.LogInformation("GetPatient called with ID: {Id}", id);
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto patientDto)
        {
            _logger.LogInformation("CreatePatient called");
            if (patientDto == null)
            {
                return BadRequest("Patient data is null.");
            }

            var patient = await _patientService.CreatePatientAsync(patientDto);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientDto patientDto)
        {
            _logger.LogInformation("UpdatePatient called with ID: {Id}", id);
            if (patientDto == null)
            {
                return BadRequest("Patient data is null.");
            }

            if (patientDto.Id != id)
            {
                return BadRequest("Patient ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPatient = await _patientService.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            var updatedPatient = await _patientService.UpdatePatientAsync(patientDto);
            return Ok(updatedPatient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            _logger.LogInformation("DeletePatient called with ID: {Id}", id);
            var deleted = await _patientService.DeletePatientAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
