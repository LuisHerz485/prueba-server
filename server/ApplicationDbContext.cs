using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server
{
    public class ApplicationDbContext : DbContext

    {
        public DbSet<Alumno> Alumno { get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
