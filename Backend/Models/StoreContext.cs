using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class StoreContext : DbContext
    {
        //constructor para inicializar la base de datos
        //pasarle el options al padre con base
        //el contexto represneta nucloe que entidades
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }
        //representacion de la tablas o entidades de la base de datos
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
