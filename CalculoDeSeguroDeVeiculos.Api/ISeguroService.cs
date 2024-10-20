namespace CalculoDeSeguroDeVeiculos
{
    public interface ISeguroService
    {
        bool GravaSeguro(SeguroDto seguroDto);
        SeguroDto PesquisaSeguro(string cpf);
    }
}
