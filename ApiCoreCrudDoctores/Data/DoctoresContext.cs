using ApiCoreCrudDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDoctores.Data
{
    public class DoctoresContext : DbContext
    {
        public DoctoresContext
        (DbContextOptions<DoctoresContext> options) : base(options) { }
        public DbSet<Doctor> Doctores { get; set; }

        public DbSet<Hospital> Hospitales { get; set; }
    }
}
