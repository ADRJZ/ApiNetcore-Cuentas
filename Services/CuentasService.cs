using apiFinanciera.DTOs.Cuentas;
using apiFinanciera.Entitys;
using apiFinanciera.Facades;

namespace apiFinanciera.Services
{
    public class CuentasService
    {
        CuentasFacade facade;

        public CuentasService()
        {
            facade = new CuentasFacade();
        }

        public async Task<Cuenta> createCuenta(CuentasRequest request)
        {
            MovimientosFacede movimientosfacade = new MovimientosFacede();

            Cuenta cuenta = new Cuenta();
            try
            {
                cuenta.ClienteId = request.idCliente;
                cuenta.Saldo = request.Saldo.GetValueOrDefault(0M);
                cuenta.TipoCuenta = (TipoCuenta)request.Tipocuenta;
                cuenta.Status = true;
                cuenta.FechaRegistro = DateTime.Now;
                cuenta.NombreCuenta = request.Nombrecuenta;
                await facade.CreateAsync(cuenta);

                if(request.Saldo > 0){
                    var movimiento = new Movimiento();
                    movimiento.Cantidad = request.Saldo.GetValueOrDefault(0M);
                    movimiento.Concepto = "Apertura de cuenta";
                    movimiento.Usuario = "";
                    movimiento.CuentaId = cuenta.Id;
                    movimiento.Status = true;
                    movimiento.FechaRegistro = DateTime.Now;
                    await movimientosfacade.CreateAsync(movimiento);
                }

                cuenta.NumeroCuenta = $"{(int)cuenta.TipoCuenta}{10000000 + cuenta.Id}";
                
                await facade.UpdateAsync(cuenta);

                return cuenta;
            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        public async Task<List<Cuenta>> getCuetasByClient(int idCliente){
            List<Cuenta> resultList = new List<Cuenta>(); 
            try
            {
                resultList = await facade.GetCuentasByIdCliente(idCliente);
                return resultList;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
     }
}