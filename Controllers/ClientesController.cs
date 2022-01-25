using apiFinanciera.DTOs;
using apiFinanciera.DTOs.Clientes;
using apiFinanciera.Entitys;
using apiFinanciera.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace apiFinanciera.Controllers
{
    [Controller]
    [EnableCors("AnotherPolicy")]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        ClientesService service;
        public ClientesController()
        {
            service = new ClientesService();
        }
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] ClienteRequest request)
        {
            Response response = new Response();
            try
            {
                var objecto = await service.createClient(request);
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
        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            Response response = new Response();
            try
            {
                var objecto = await service.getAllClients();
                response.content = objecto;
                response.success = true;
                response.status = 200;
            }
            catch (System.Exception)
            {
                throw;
            }
            return StatusCode(response.status, response);
        }


    }
}