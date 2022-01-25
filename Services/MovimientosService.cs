using apiFinanciera.DTOs.Movimientos;
using apiFinanciera.Entitys;
using apiFinanciera.Facades;

namespace apiFinanciera.Services
{
    public class MovimientosService
    {
        MovimientosFacede facade;

        public MovimientosService()
        {
            facade = new MovimientosFacede();
        }

        public async Task<Movimiento> abonarCuentaAhorro(MovimientoCuentaAhorroRequest request)
        {
            Movimiento movimientoAbono = new Movimiento();
            CuentasFacade facadeCuenta = new CuentasFacade();
            try
            {

                var cuentaAbono = await facadeCuenta.GetByNumeroCuenta(request.NumeroCuentaAbono);

                if (request.IdcuentaOrigen > 0)
                {

                    var cuentaOrigen = await facadeCuenta.GetByIdAsync((int)request.IdcuentaOrigen);

                    var movimientoCargo = new Movimiento();

                    movimientoCargo.Concepto = request.Concepto;
                    movimientoCargo.TipoMovimiento = TipoMovimiento.CARGO;
                    movimientoCargo.Usuario = request.Usuario;
                    movimientoCargo.Cliente = request.IdCliente;
                    movimientoCargo.CuentaId = (int)request.IdcuentaOrigen;
                    movimientoCargo.Status = true;
                    movimientoCargo.FechaRegistro = DateTime.Now;
                    


                    await facade.CreateAsync(movimientoCargo);

                    cuentaOrigen.Saldo -= request.Cantidad;

                    await facadeCuenta.UpdateAsync(cuentaOrigen);

                }else{

                    movimientoAbono.TipoMovimiento = TipoMovimiento.ABONO;
                    movimientoAbono.Cantidad = request.Cantidad;
                    movimientoAbono.Usuario = request.Usuario;
                    movimientoAbono.CuentaId = cuentaAbono.Id;
                    movimientoAbono.Concepto = request.Concepto;
                    movimientoAbono.Status = true;
                    movimientoAbono.FechaRegistro = DateTime.Now;

                    await facade.CreateAsync(movimientoAbono);

                }
                cuentaAbono.Saldo += request.Cantidad;
                await facadeCuenta.UpdateAsync(cuentaAbono);

                return movimientoAbono;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<Movimiento> retirarCuentaAhorro(RetirarCuentaAhorro request)
        {
            Movimiento movimientoRetiroAhorro = new Movimiento();
            CuentasFacade facadeCuenta = new CuentasFacade();
            try
            {

                var cuentaAhorroRetiro = await facadeCuenta.GetByNumeroCuenta(request.NumeroCuenta);

                if( cuentaAhorroRetiro.Saldo- request.Cantidad < 0){
                    throw new Exception("No cuenta con saldo Suficiente para realizar el retiro");
                }

                cuentaAhorroRetiro.Saldo -= request.Cantidad;

                movimientoRetiroAhorro.TipoMovimiento = TipoMovimiento.CARGO;
                movimientoRetiroAhorro.Cantidad = request.Cantidad;
                movimientoRetiroAhorro.Concepto = request.Concepto;
                movimientoRetiroAhorro.FechaRegistro = DateTime.Now;
                movimientoRetiroAhorro.CuentaId = cuentaAhorroRetiro.Id;
                movimientoRetiroAhorro.Status = true;

                await facade.CreateAsync(movimientoRetiroAhorro);
                await facadeCuenta.UpdateAsync(cuentaAhorroRetiro);
                
                Movimiento movimientoAbonoCorriente = new Movimiento();
                var cuentaCorriente = await facadeCuenta.GetByCuentaCorrienteByIdCliente(request.IdCliente);

                // movimientoAbonoCorriente.TipoMovimiento = TipoMovimiento.ABONO;
                // movimientoAbonoCorriente.Cantidad = request.Cantidad;
                // movimientoAbonoCorriente.Concepto = request.Concepto;
                // movimientoAbonoCorriente.FechaRegistro = DateTime.Now;
                // movimientoAbonoCorriente.CuentaId = cuentaCorriente.Id;
                // movimientoAbonoCorriente.Status = true;

                // await facade.CreateAsync(movimientoAbonoCorriente);

                // cuentaCorriente.Saldo += request.Cantidad;
                // await facadeCuenta.UpdateAsync(cuentaCorriente);
                return movimientoRetiroAhorro;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Movimiento>> getMovimientosByCuenta(int idCuenta){
            List<Movimiento> resultList = new List<Movimiento>();
            try
            {
                resultList = await facade.GetMovimientosByCuenta(idCuenta);
                return resultList;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}