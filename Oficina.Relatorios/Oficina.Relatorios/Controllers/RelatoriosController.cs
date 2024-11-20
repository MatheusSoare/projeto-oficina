using Domain.Entities.Command;
using Domain.Entities.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Oficina.Relatorios.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly ILogger<RelatoriosController> _logger;
        private readonly IRelatoriosService _relatoriosService;

        public RelatoriosController(ILogger<RelatoriosController> logger,
            IRelatoriosService relatoriosService)
        {
            _relatoriosService = relatoriosService;
            _logger = logger;   
        }

        [HttpPost("GerarNotaClienteXlsx")]
        public IActionResult GerarNotaXlsx([FromBody] GerarNotaClienteCmd parametro)
        {
            try
            {
                _logger.LogInformation($"INICIANDO GERAÇÃO DA NOTA DO CLIENTE {parametro.Nome}");
                var dadosCliente = new GerarNotaClienteDTO(parametro);
                var resultado = _relatoriosService.GerarNotaClienteXlsx(dadosCliente);

                return File(new MemoryStream(resultado.GetAsByteArray()), "application/octet-stream", $"Nota-{dadosCliente.Cliente.Cpf}.xlsx");
            }
            catch (Exception ex) 
                {
                _logger.LogError($"ERRO AO GERAR NOTA PARA O CLIENTE: {parametro.Nome}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GerarNotaClientePdf")]
        public IActionResult GerarNotaPdf([FromBody] GerarNotaClienteCmd parametro)
        {
            try
            {
                _logger.LogInformation($"INICIANDO GERAÇÃO DA NOTA DO CLIENTE {parametro.Nome}");
                var dadosCliente = new GerarNotaClienteDTO(parametro);
                var document = _relatoriosService.GerarNotaClientePdf(dadosCliente);

                using (MemoryStream stream = new MemoryStream())
                {
                    document.Save(stream, false);
                    stream.Position = 0;

                    return File(stream.ToArray(), "application/pdf", $"Nota-Serviço-{parametro.Cpf}.pdf");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERRO AO GERAR NOTA PARA O CLIENTE: {parametro.Nome}");
                return BadRequest(ex.Message);
            }
        }
    }
}
