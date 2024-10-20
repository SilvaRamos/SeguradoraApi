using CalculoDeSeguroDeVeiculos.Api.Model;
using CalculoDeSeguroDeVeiculos.Repository.Interfaces;
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

        [HttpPost(Name = "GravaSeguro")]
        public void Post(SeguroDto seguroDto)
        {
            ////1- Valida os dados de entrada

            ////2- Calcula o valor do Seguro
            ////seguro.calculaPremioComercial(seguro.VeiculoValor);

            ////3-Mapeia Entidades
            //SeguroModel seguro = new SeguroModel
            //{
            //    Id = new Guid(),
            //    CPFSegurado = seguroDto.segurado.CPF,
            //    VeiculoMarca = seguroDto.veiculo.Marca,
            //    VeiculoModelo = seguroDto.veiculo.Modelo,
            //    VeiculoValor = seguroDto.veiculo.Valor,
            //    ValorSeguro = 1000
            //};

            ////4- Grava o seguro
            //_seguroRepository.Grava(seguro);
            _seguroService.GravaSeguro(seguroDto);
        }

        [HttpGet(Name = "CalculaSeguro")]
        public IActionResult Get(SeguroModel seguro)
        {
            var result = _seguroRepository.ListaTodos();
                
            return Ok(result);
        }

        [HttpGet]
        [Route("PesquisaSeguro/{cpf}")]
        public IActionResult PesquisaSeguro(string cpf)
        {
            //var result = _seguroRepository.ListaPorCpf(cpf);
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
