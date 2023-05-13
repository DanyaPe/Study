namespace Study__MVC_
{ 
using Microsoft.EntityFrameworkCore;
    using Microsoft.Identity.Client;
    using Study__MVC_.Models;

      public class ApplicationContext : DbContext 
        {
            public DbSet<PlayerViewModel> player { get; set; } = null!;

            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=localhost;user=root;password=521060DZ521060;database=study(MCV);", new MySqlServerVersion(new Version(8, 0, 33)));
        }
}