using CalculoDeSeguroDeVeiculos.Aplicacao;
using CalculoDeSeguroDeVeiculos.Aplicacao.DTOs;
using CalculoDeSeguroDeVeiculos.Aplicacao.Interfaces;
using CalculoDeSeguroDeVeiculos.Dominio.Interfaces;
using CalculoDeSeguroDeVeiculos.Dominio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalculoDeSeguroDeVeiculos.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CalculoDeSeguroDeVeiculosController : ControllerBase
    {
        private readonly ISeguroRepository _seguroRepository;
        private readonly ISeguroService _seguroService;


        public CalculoDeSeguroDeVeiculosController(ISeguroRepository seguroRepository, ISeguroService seguroService)
        {
            _seguroRepository = seguroRepository;
            _seguroService = seguroService;
        }

        [HttpPost]
        [Route("GravaSeguro")]
        public void Post(SeguroDto seguroDto)
        {
            _seguroService.GravaSeguro(seguroDto);
        }

        [HttpGet]
        [Route("ListaSeguros")]
        public IActionResult Get(SeguroModel seguro)
        {
            var result = _seguroRepository.ListaTodos();
                
            return Ok(result);
        }

        [HttpGet]
        [Route("PesquisaSeguro/{cpf}")]
        public IActionResult PesquisaSeguro(string cpf)
        {
            var result = _seguroService.PesquisaSeguro(cpf);
            return Ok(result); 
        }

        [HttpGet]
        [Route("EmiteRelatorio")]
        [AllowAnonymous]
        public IActionResult EmiteRelatorio()
        {
            List<Decimal> valores = _seguroRepository.listaTodosOsValores();

            decimal mediaAritmeticaDoSeguros = Calculos.calculaMediaAritmetica(valores);

            string relatorio = "{ 'titulo':'Relatório de Seguros', 'mediaAritmeticaSeguros':"+ mediaAritmeticaDoSeguros +"}";

            return Ok(relatorio);
        }

        [HttpGet]
        [Route("CalculaSeguro")]
        
        public IActionResult CalculaSeguro(Decimal valorDoVeiculo)
        {
            var valorDoSeguro = Calculos.CalculaSeguro(valorDoVeiculo);
            return Ok(valorDoSeguro);
        }

    }
}
