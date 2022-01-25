using apiFinanciera.Entitys;
using apiFinanciera.Repositorys;

namespace apiFinanciera.Facades
{
    public class ClientesFacede
    {
        ClientesRepository repository;

        public ClientesFacede()
        {
            this.repository = new ClientesRepository();
        }

        public async Task<Cliente> CreateAsync(Cliente objeto)
        {
            return await repository.CreateAsync(objeto);
        }

        public async Task<Cliente> UpdateAsync(Cliente objeto)
        {
            return await repository.UpdateAsync(objeto);
        }

        public async Task<Cliente> GetByIdAsync(int Id)
        {
            return await repository.GetByIdAsync(Id);
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

    }
}