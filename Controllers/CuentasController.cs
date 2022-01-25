using apiFinanciera.DTOs;
using apiFinanciera.DTOs.Cuentas;
using apiFinanciera.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiFinanciera.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class CuentasController : Controller
    {
        CuentasService service;
        public CuentasController()
        {
            service = new CuentasService();
        }
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] CuentasRequest request)
        {
            Response response = new Response();
            try
            {
                var objecto = await service.createCuenta(request);
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

        [HttpGet("{idCliente}")]
        public async Task<ActionResult> getCuentasByClient([FromRoute] int idCliente)
        {
            Response response = new Response();
            try
            {
                var objecto = await service.getCuetasByClient(idCliente);
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