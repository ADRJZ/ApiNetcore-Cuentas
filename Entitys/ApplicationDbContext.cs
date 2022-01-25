using Microsoft.EntityFrameworkCore;

namespace apiFinanciera.Entitys
{
    public class ApplicationDbContext : DbContext
    {
        public string stringConnection = "";

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public ApplicationDbContext()
        {
            this.stringConnection = "Server=localhost,1433;Database=Financiera;User Id=sa;Password=Admin.123456;";
        }

        public ApplicationDbContext(String _StringConnection)
        {
            this.stringConnection = _StringConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(this.stringConnection);
                    //.EnableSensitiveDataLogging(true)
                    //.UseLazyLoadingProxies()  //Para carga perezosa, incompleto: con errores en productivo.
                    //.UseLoggerFactory(MyLoggerFactory); // Desactivar en productivo, sirve para ver consultas a base de datos
        }

        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
    }
}