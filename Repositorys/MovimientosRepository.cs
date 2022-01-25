using apiFinanciera.Entitys;
using Microsoft.EntityFrameworkCore;

namespace apiFinanciera.Repositorys
{
    public class MovimientosRepository : RepositoryBase<Movimiento>
    {
        public MovimientosRepository()
        {

        }

        public async Task<List<Movimiento>> GetMovimientosByCuenta(int IdCuenta, bool PropNav = false)
        {
            List<Movimiento> resultList = new List<Movimiento>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var query = context.Set<Movimiento>().AsQueryable().AsNoTracking();
                    if (PropNav)
                    {
                        foreach (var property in context.Model.FindEntityType(typeof(Movimiento)).GetNavigations())
                            query = query.Include(property.Name);
                    }
                    resultList = await query.Where(x => x.CuentaId == IdCuenta && x.Status == true).AsNoTracking().ToListAsync();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return resultList;
        }
    }
}