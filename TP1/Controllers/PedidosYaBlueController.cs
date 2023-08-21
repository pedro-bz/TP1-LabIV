using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP1.Services;

namespace TP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosYaBlueController : ControllerBase
    {
        private readonly PedidosYaBlueService _service;

        public PedidosYaBlueController(PedidosYaBlueService service)
        {
            _service = service;
        }

        [HttpPost("CreateOrder")]
        public ActionResult<string> CreateNewOrder(string clientType)
        {
            return Ok(_service.CreateNewOrder(clientType));
        }

        [HttpGet("GetLocation")]
        public ActionResult<string> GetLocation()
        {
            return Ok(_service.GetLocation());
        }

    }
}
