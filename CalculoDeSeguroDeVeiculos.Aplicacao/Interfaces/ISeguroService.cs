using CalculoDeSeguroDeVeiculos.Aplicacao.DTOs;

namespace CalculoDeSeguroDeVeiculos.Aplicacao.Interfaces
{
    public interface ISeguroService
    {
        bool GravaSeguro(SeguroDto seguroDto);
        SeguroDto PesquisaSeguro(string cpf);
    }
}
