using CalculoDeSeguroDeVeiculos.Dominio.Models;

namespace CalculoDeSeguroDeVeiculos.Aplicacao.DTOs
{
    public class SeguroDto
    {
        public SeguradoModel segurado { get; set; }

        public VeiculoModel veiculo { get; set; }
    }
}