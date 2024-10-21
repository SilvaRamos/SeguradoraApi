using CalculoDeSeguroDeVeiculos.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoDeSeguroDeVeiculos.Tests
{
    public class CalculosTesteUnitario
    {
        [Fact]
        public void calculaTaxaDeRisco_RetornaDecimal()
        {
            //Arrange
            decimal valorVeiculo = 1000M;
            decimal valorEsperado = 2.5M;

            //Act
            decimal taxaDeRisco = Calculos.calculaTaxaDeRisco(valorVeiculo);

            //Assert
            Assert.Equal(valorEsperado, taxaDeRisco);
        }

        [Fact]
        public void calculaPremioDeRisco_RetornaDecimal()
        {
            //Arrange
            decimal valorVeiculo = 1000M;
            //decimal taxaDeRisco = 2.5M;

            decimal valorEsperado = 2500M;

            //Act
            decimal PremioDeRisco = Calculos.calculaPremioDeRisco(valorVeiculo);

            //Assert
            Assert.Equal(valorEsperado, PremioDeRisco);
        }

        //[Fact]
        //public void calculaPremioPuro_RetornaDecimal()
        //{
        //    //Arrange
        //    decimal valorVeiculo = 1000M;
        //    decimal valorEsperado = 2.5M;

        //    //Act
        //    decimal taxaDeRisco = Calculos.calculaTaxaDeRisco(valorVeiculo);

        //    //Assert
        //    Assert.Equal(valorEsperado, taxaDeRisco);
        //}

        //[Fact]
        //public void calculaPremioComercial_RetornaDecimal()
        //{
        //    //Arrange
        //    decimal valorVeiculo = 1000M;
        //    decimal valorEsperado = 2.5M;

        //    //Act
        //    decimal taxaDeRisco = Calculos.calculaTaxaDeRisco(valorVeiculo);

        //    //Assert
        //    Assert.Equal(valorEsperado, taxaDeRisco);
        //}
    }
}
