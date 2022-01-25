using apiFinanciera.DTOs.Clientes;
using apiFinanciera.Entitys;
using apiFinanciera.Facades;
using apiFinanciera.Repositorys;

namespace apiFinanciera.Services
{
    public class ClientesService
    {
        public ClientesFacede facade;
        public CuentasFacade cuentasFacade;

        public ClientesService()
        {   
            facade = new ClientesFacede();
            cuentasFacade = new CuentasFacade();
        }

        public async Task<List<Cliente>> getAllClients(){
            try
            {
                return await facade.GetAllAsync();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public async Task<Cliente> createClient(ClienteRequest clienteRequest)
        {
            Cliente cliente = new Cliente();

            try
            {
                cliente.Nombre = clienteRequest.Nombre;
                cliente.ApellidoPaterno = clienteRequest.ApellidoPaterno;
                cliente.ApellidoMaterno = clienteRequest.ApellidoMaterno;
                cliente.NumeroIdentificacion = clienteRequest.Identificacion;
                cliente.NombreCompleto = $"{clienteRequest.Nombre} {clienteRequest.ApellidoPaterno}  {clienteRequest.ApellidoMaterno}";
                cliente.Status = true;
                cliente.FechaRegistro = DateTime.Now;

                await facade.CreateAsync(cliente);

                Cuenta cuenta = new Cuenta();
                
                cuenta.ClienteId = cliente.Id;
                cuenta.Saldo = 0.0M;
                cuenta.TipoCuenta = TipoCuenta.CORRIENTE;
                cuenta.NombreCuenta = "Cuenta corriente inicial";
                cuenta.Status = true;
                cuenta.FechaRegistro = DateTime.Now;
                await cuentasFacade.CreateAsync(cuenta);

                cuenta.NumeroCuenta = $"{(int)TipoCuenta.CORRIENTE}{10000000 + cuenta.Id}";
                
                await cuentasFacade.UpdateAsync(cuenta);

                return cliente;

            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }
}