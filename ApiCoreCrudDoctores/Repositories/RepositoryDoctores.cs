using ApiCoreCrudDoctores.Data;
using ApiCoreCrudDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDoctores.Repositories
{
    public class RepositoryDoctores
    {
        private DoctoresContext context;

        public RepositoryDoctores(DoctoresContext context)
        {
            this.context = context;
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            return await this.context.Doctores.ToListAsync();
        }

        public async Task<Doctor> FindDotoresAsync(int iddoctor)
        {
            return await
                this.context.Doctores.FirstOrDefaultAsync
                (x => x.IdDoctor == iddoctor);
        }

        public async Task<List<string>> GetHospitales()
        {
            var consulta = (from datos in this.context.Hospitales
                            select datos.Nombre).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctoresHospitalAsync(string nom_hospital)
        {

            Hospital hospital = await
                this.context.Hospitales.FirstOrDefaultAsync
                        (x => x.Nombre == nom_hospital);

            return await
            this.context.Doctores.Where(z => z.IdHospital == hospital.IdHospital).ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctoresSalarioAsync(int salario, string nom_hospital)
        {
            Hospital hospital = await
                this.context.Hospitales.FirstOrDefaultAsync
                        (x => x.Nombre == nom_hospital);

            return await this.context.Doctores.Where(x => x.Salario >= salario && x.IdHospital == hospital.IdHospital)
                .ToListAsync();
        }


        public async Task InsertarDoctorAsync(int idhospital, int id, string apellido, string especialidad, int salario)
        {
            Doctor doctor = new Doctor();
            doctor.IdDoctor = id;
            doctor.IdHospital = idhospital;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Salario = salario;
            this.context.Doctores.Add(doctor);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDotorAsync(int idhospital, int id, string apellido, string especialidad, int salario)
        {
            Doctor doctor = await this.FindDotoresAsync(id);
            doctor.IdDoctor = id;
            doctor.IdHospital = idhospital;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Salario = salario;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            Doctor doctor = await this.FindDotoresAsync(id);
            this.context.Doctores.Remove(doctor);
            await this.context.SaveChangesAsync();
        }
    }
}
