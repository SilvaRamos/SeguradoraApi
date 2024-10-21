namespace CalculoDeSeguroDeVeiculos.Dominio.Models
{
    public class SeguroModel
    {
        public required Guid Id { get; set; }
        public required Guid SeguradoId { get; set; }
        public Decimal VeiculoValor { get; set; }
        public required string VeiculoMarca { get; set; }
        public required string VeiculoModelo { get; set; }
        public Decimal ValorSeguro { get; set; }
    }
}
