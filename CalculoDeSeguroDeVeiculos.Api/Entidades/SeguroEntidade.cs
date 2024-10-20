namespace CalculoDeSeguroDeVeiculos.Api.Model
{
    public class SeguroEntidade
    {
        

        public required Guid Id { get; set; }
        public required SeguradoModel segurado { get; set; }
        public required VeiculoModel veiculo { get; set; }
       
        
        
    }
}
