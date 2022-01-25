using apiFinanciera.Entitys;
using apiFinanciera.Repositorys;

namespace apiFinanciera.Facades
{
    public class MovimientosFacede
    {
        MovimientosRepository repository;
        public MovimientosFacede()
        {
            this.repository = new MovimientosRepository();
        }

        public async Task<Movimiento> CreateAsync(Movimiento objeto)
        {
            return await repository.CreateAsync(objeto);
        }

        public async Task<Movimiento> UpdateAsync(Movimiento objeto)
        {
            return await repository.UpdateAsync(objeto);
        }


        public async Task<List<Movimiento>> GetMovimientosByCuenta(int IdCuenta)
        {
            return await repository.GetMovimientosByCuenta(IdCuenta);
        }
    }
}