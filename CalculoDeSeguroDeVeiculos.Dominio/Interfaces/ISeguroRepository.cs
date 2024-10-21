using CalculoDeSeguroDeVeiculos.Dominio.Models;

namespace CalculoDeSeguroDeVeiculos.Dominio.Interfaces
{
    public interface ISeguroRepository
    {
        List<SeguroModel> ListaTodos();
        SeguroModel ListaPorId(Guid idSegurado);
        List<Decimal> listaTodosOsValores();
        void Grava(SeguroModel seguro);
    }
}
