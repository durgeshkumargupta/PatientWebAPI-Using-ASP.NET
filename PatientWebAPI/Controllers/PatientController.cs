using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Data;

namespace PatientWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly DataContext context;
        public PatientController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> Get()
        {
            return Ok(await context.Patients.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Patient>>> Post(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return Ok(await context.Patients.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var p=await context.Patients.FindAsync(id);
            if (p == null)
                return BadRequest("Patient Not Available");
            return Ok(p);
        }

       [HttpPut("{id}")]
       public async Task<ActionResult<List<Patient>>> UpdatById(int id,Patient patient)
        {
            var p = await context.Patients.FindAsync(id);
            if (p == null)
                return BadRequest("Patient Not Found");
         //   p.Id = patient.Id;
            p.Address = patient.Address;
            p.Name = patient.Name;
            p.Prescription = patient.Prescription;
            p.Doctor = patient.Doctor;

            await context.SaveChangesAsync();
            return Ok(await context.Patients.ToListAsync());

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteById(int id)
        {
            var p=await context.Patients.FindAsync(id);
            if (p == null)
                return BadRequest("Patient Not Availble");
            context.Patients.Remove(p);
            context.SaveChanges();
            return Ok(await context.Patients.ToListAsync());
        }

    }
}
