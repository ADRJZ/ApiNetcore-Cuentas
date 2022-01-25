using apiFinanciera.Entitys;
using Microsoft.EntityFrameworkCore;

namespace apiFinanciera.Repositorys
{
    public abstract class RepositoryBase<T> where T : EntityBase
    {

        public RepositoryBase()
        {

        }
        public async Task<T> CreateAsync(T objeto)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Add(objeto);
                    await context.SaveChangesAsync();
                }
                return objeto;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }


        public async Task<T> UpdateAsync(T objeto)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(objeto).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                return objeto;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteAsync(T objeto)
        {
            bool band = false;
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(objeto).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    band = true;
                }
                return band;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T objeto = null;
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var query = context.Set<T>().AsQueryable();

                    objeto = await query.FirstOrDefaultAsync(x => x.Id == id);
                }
                return objeto;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public async Task<List<T>> GetAllAsync()
        {
            List<T> resultList = new List<T>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var query = context.Set<T>().AsQueryable();
                    foreach (var property in context.Model.FindEntityType(typeof(T)).GetNavigations())
                        query = query.Include(property.Name);
                        
                    resultList = await query.Where(x => x.Status == true).ToListAsync();
                }
                return resultList;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}