using CalculoDeSeguroDeVeiculos.Api.Model;

namespace CalculoDeSeguroDeVeiculos
{
    public class SeguroDto
    {
        public SeguradoModel segurado { get; set; }

        public VeiculoModel veiculo { get; set; }
    }
}