using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
namespace WebAPI.Data
{
    public class DBEscuelaAPIContext:DbContext
    {
        public DBEscuelaAPIContext(DbContextOptions<DBEscuelaAPIContext> options):base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }

    }
}
