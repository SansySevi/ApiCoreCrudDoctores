using ApiCoreCrudDoctores.Models;
using ApiCoreCrudDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> Get()
        {
            return await this.repo.GetDoctoresAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            return await this.repo.FindDotoresAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult>
            InsertDepartamento(Doctor doctor)
        {
            await this.repo.InsertarDoctorAsync
                (doctor.IdHospital, doctor.IdDoctor, doctor.Apellido
                , doctor.Especialidad, doctor.Salario);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor
            (Doctor doctor)
        {
            await this.repo.UpdateDotorAsync(doctor.IdHospital, doctor.IdDoctor, doctor.Apellido
                , doctor.Especialidad, doctor.Salario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await this.repo.DeleteDoctorAsync(id);
            return Ok();
        }


        /**/
        //api/empleados/oficios
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Hospitales()
        {
            return await this.repo.GetHospitales();
        }

        [HttpGet]
        [Route("[action]/{hospital}")]
        public async Task<ActionResult<List<Doctor>>> DoctoresHospital(string hospital)
        {
            return await this.repo.GetDoctoresHospitalAsync(hospital);
        }

        [HttpGet]
        [Route("[action]/{salario}/{hospital}")]
        public async Task<ActionResult<List<Doctor>>> EmpleadosSalario(int salario, string hospital)
        {
            return await this.repo.GetDoctoresSalarioAsync(salario, hospital);
        }

    }
}
