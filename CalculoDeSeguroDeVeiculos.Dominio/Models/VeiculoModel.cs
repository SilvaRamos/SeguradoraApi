namespace CalculoDeSeguroDeVeiculos.Dominio.Models
{
    public class VeiculoModel
    {
        public required string  Marca {  get; set; }
        public required string Modelo { get; set; }
        public required decimal Valor { get; set; }
    }
}
