namespace CalculoDeSeguroDeVeiculos
{
    public static class Calculos
    {
        private static readonly decimal MARGEM_SEGURANCA = 0.05M;
        private static readonly decimal LUCRO = 0.03M;


        #region Calculo do Seguro
            public static decimal CalculaSeguro(Decimal valorDoVeiculo)
            {
                return calculaPremioComercial(valorDoVeiculo);
            }
            public static Decimal calculaPremioComercial(decimal valorDoVeiculo)
            {
                decimal premioPuro = calculaPremioPuro(valorDoVeiculo);
                return LUCRO * premioPuro;
            }
            public static Decimal calculaPremioPuro(decimal valorVeiculo)
            {
                decimal premioDeRisco = calculaPremioDeRisco(valorVeiculo);

                return premioDeRisco * (1 + MARGEM_SEGURANCA);
            }
            public static Decimal calculaPremioDeRisco(decimal valorVeiculo)
            {
                decimal taxaDeRisco = calculaTaxaDeRisco(valorVeiculo);

                return taxaDeRisco * valorVeiculo;
            }
            public static Decimal calculaTaxaDeRisco(decimal valorVeiculo)
            {
                return (valorVeiculo * 5) / (2 * valorVeiculo);
            }
        #endregion

        //Retorna a media aritmetica de uma lista de valores
        public static decimal calculaMediaAritmetica(List<Decimal> valores)
        {
            return valores.Sum() / valores.Count();
        }

    }
}
