namespace CalculoDeSeguroDeVeiculos.Dominio.Models
{
    public class SeguradoModel
    {
        public required Guid id { get; set; } 
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required int idade { get; set; }
    }
}
