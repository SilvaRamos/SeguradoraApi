using CalculoDeSeguroDeVeiculos.Api.Model;
using CalculoDeSeguroDeVeiculos.Controllers;

namespace CalculoDeSeguroDeVeiculos.Repository.Interfaces
{
    public interface ISeguroRepository
    {
        List<SeguroModel> ListaTodos();
        //List<SeguroModel> ListaPorCpf(string cpf);
        SeguroModel ListaPorId(Guid idSegurado);
        List<Decimal> listaTodosOsValores();
        void Grava(SeguroModel seguro);
    }
}
