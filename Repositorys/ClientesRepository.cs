using apiFinanciera.Entitys;
using Microsoft.EntityFrameworkCore;

namespace apiFinanciera.Repositorys
{
    public class ClientesRepository : RepositoryBase<Cliente>
    {
        public ClientesRepository()
        {

        }

        public async Task<List<Cuenta>> GetCuentasByClient(int IdCliente, bool PropNav = false)
        {
            List<Cuenta> resultList = new List<Cuenta>();
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
                    resultList = await query.Where(x => x.Cliente.Id == IdCliente && x.Status == true).AsNoTracking().ToListAsync();
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