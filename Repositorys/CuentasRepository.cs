using apiFinanciera.Entitys;
using Microsoft.EntityFrameworkCore;

namespace apiFinanciera.Repositorys
{
    public class CuentasRepository : RepositoryBase<Cuenta>
    {
        public CuentasRepository()
        {

        }

        public async Task<Cuenta> GetCuentaByNumeroCuenta(String NumeroCuenta, bool PropNav = false)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var query = context.Set<Cuenta>().AsQueryable().AsNoTracking();
                    if (PropNav)
                    {
                        foreach (var property in context.Model.FindEntityType(typeof(Cuenta)).GetNavigations())
                            query = query.Include(property.Name);
                    }
                    cuenta = await query.FirstOrDefaultAsync(x => x.NumeroCuenta == NumeroCuenta && x.Status == true);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return cuenta;
        }

        public async Task<Cuenta> GetCuentaCorrienteByIdCliente(int IdCliente, bool PropNav = false)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var query = context.Set<Cuenta>().AsQueryable().AsNoTracking();
                    if (PropNav)
                    {
                        foreach (var property in context.Model.FindEntityType(typeof(Cuenta)).GetNavigations())
                            query = query.Include(property.Name);
                    }
                    cuenta = await query.FirstOrDefaultAsync(x => x.ClienteId == IdCliente && x.Status == true && x.TipoCuenta == TipoCuenta.CORRIENTE);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return cuenta;
        }

        public async Task<List<Cuenta>> GetCuentasByIdCliente(int IdCliente, bool PropNav = false)
        {
            List <Cuenta> cuentas = new List<Cuenta>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var query = context.Set<Cuenta>().AsQueryable().AsNoTracking();
                    if (PropNav)
                    {
                        foreach (var property in context.Model.FindEntityType(typeof(Cuenta)).GetNavigations())
                            query = query.Include(property.Name);
                    }
                    cuentas = await query.Where(x => x.ClienteId == IdCliente && x.Status == true).ToListAsync();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return cuentas;
        }
    }
}