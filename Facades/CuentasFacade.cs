using apiFinanciera.Entitys;
using apiFinanciera.Repositorys;

namespace apiFinanciera.Facades
{
    public class CuentasFacade
    {
        CuentasRepository repository;

        public CuentasFacade()
        {
            this.repository = new CuentasRepository();
        }

        public async Task<Cuenta> CreateAsync(Cuenta objeto)
        {
            return await repository.CreateAsync(objeto);
        }

        public async Task<Cuenta> UpdateAsync(Cuenta objeto)
        {
            return await repository.UpdateAsync(objeto);
        }

        public async Task<Cuenta> GetByIdAsync(int Id)
        {
            return await repository.GetByIdAsync(Id);
        }

        public async Task<Cuenta> GetByNumeroCuenta(String Id)
        {
            return await repository.GetCuentaByNumeroCuenta(Id);
        }


        public async Task<Cuenta> GetByCuentaCorrienteByIdCliente(int IdCliente)
        {
            return await repository.GetCuentaCorrienteByIdCliente(IdCliente);
        }


        public async Task<List<Cuenta>> GetCuentasByIdCliente(int IdCliente)
        {
            return await repository.GetCuentasByIdCliente(IdCliente);
        }


    }
}