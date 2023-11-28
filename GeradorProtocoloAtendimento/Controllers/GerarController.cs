using GeradorProtocoloAtendimento.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeradorProtocoloAtendimento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GerarController : ControllerBase
    {
        private readonly ILogger<GerarController> _logger;
        private readonly IGerarProtocolo _gerarProtocolo;

        public GerarController(ILogger<GerarController> logger, IGerarProtocolo gerarProtocolo)
        {
            _logger = logger;
            _gerarProtocolo = gerarProtocolo;
        }

        [HttpGet]
        public IActionResult GerarProtocolo(string empresaId, DateTime data)
        {
            var protocolo = _gerarProtocolo.GerarProtocolo(empresaId, data, out string erro);
            return string.IsNullOrEmpty(erro) ? Ok(protocolo) : BadRequest(erro);
        }
    }
}