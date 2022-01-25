using Microsoft.AspNetCore.Mvc;
using apiFinanciera.DTOs.Movimientos;
using apiFinanciera.DTOs;
using apiFinanciera.Services;

namespace apiFinanciera.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class MovimientosController : Controller
    {

        MovimientosService service;
        public
        MovimientosController()
        {
            service = new MovimientosService();
        }


        [HttpPost("Ahorro/Abono")]
        public async Task<ActionResult> AbonoCuentadeAhorro([FromBody] MovimientoCuentaAhorroRequest request)
        {
            Response response = new Response();
            try
            {
                var objecto = await service.abonarCuentaAhorro(request);
                response.content = objecto;
                response.status = 201;
                response.success = true;

            }
            catch (System.Exception)
            {

                throw;
            }
            return StatusCode(response.status, response);
        }

        [HttpPost("Ahorro/Retiro")]
        public async Task<ActionResult> RetiroCuentadeAhorro([FromBody] RetirarCuentaAhorro request)
        {
            Response response = new Response();
            try
            {
                var objecto = await service.retirarCuentaAhorro(request);
                response.content = objecto;
                response.status = 201;
                response.success = true;

            }
            catch (System.Exception e)
            {
                response.status = 404;
                response.content = e.Message;

            }
            return StatusCode(response.status, response);
        }

        [HttpGet("{idCuenta}")]
        public async Task<ActionResult> getMovimientosByCuenta([FromRoute] int idCuenta)
        {
            Response response = new Response();
            try
            {
                var objecto = await service.getMovimientosByCuenta(idCuenta);
                response.content = objecto;
                response.status = 200;
                response.success = true;

            }
            catch (System.Exception)
            {
                throw;
            }
            return StatusCode(response.status, response);
        }

    }
}