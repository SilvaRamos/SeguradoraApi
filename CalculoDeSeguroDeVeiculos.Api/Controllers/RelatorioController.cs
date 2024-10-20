using CalculoDeSeguroDeVeiculos.Api.Model;
using CalculoDeSeguroDeVeiculos.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoDeSeguroDeVeiculos.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ISeguroRepository _seguroRepository;

        public RelatorioController(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }

        [HttpGet(Name = "Relatorio")]
        public IEnumerable<SeguroModel> Get(SeguroModel seguro)
        {

            return _seguroRepository.ListaTodos();
        }

         
    }
}
