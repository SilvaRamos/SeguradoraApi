using CalculoDeSeguroDeVeiculos.Aplicacao.DTOs;
using CalculoDeSeguroDeVeiculos.Aplicacao.Interfaces;
using CalculoDeSeguroDeVeiculos.Dominio.Interfaces;
using CalculoDeSeguroDeVeiculos.Dominio.Models;

namespace CalculoDeSeguroDeVeiculos.Aplicacao.Services

{
    public class SeguroServico : ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;
        private readonly SeguradoClient _seguradoClient;

        public SeguroServico(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
            _seguradoClient = new SeguradoClient();
        }
        public bool GravaSeguro(SeguroDto seguroDto)
        {
            bool result = false;

            //1. Calcula o valor do seguro
            Decimal valorDoSeguro = Calculos.CalculaSeguro(seguroDto.veiculo.Valor);

            //TODO: colocar em um método dedicado ao mapeamento
            SeguroModel seguro = new SeguroModel
            {
                Id = Guid.NewGuid(),
                SeguradoId = seguroDto.segurado.id,
                VeiculoMarca = seguroDto.veiculo.Marca,
                VeiculoModelo = seguroDto.veiculo.Modelo,
                VeiculoValor = seguroDto.veiculo.Valor,
                ValorSeguro = valorDoSeguro
            };

            //2. grava segurado
            //SeguradoClient segurado = new SeguradoClient();

            var novoSeguradoId = _seguradoClient.gravaSegurado(seguroDto.segurado).id;

            if (!String.IsNullOrEmpty(novoSeguradoId.ToString()))
            {
                //3. grava seguro
                seguro.SeguradoId = novoSeguradoId;

                _seguroRepository.Grava(seguro);

                result = true;
            }

            return result;
        }

        //Localiza o segurado pelo Cpf e o Seguro pelo Id do Segurado
        public SeguroDto PesquisaSeguro(string cpf)
        {
            SeguroDto seguroLocalizado = new SeguroDto { };

            try{
                //1. busca segurado por cpf
                var _segurado = _seguradoClient.buscaSeguradoPorCpf(cpf).FirstOrDefault();

                //2. busca o seguro do segurado localizado no passo anterior
                if (_segurado != null)
                {
                    var dadosSeguroLocalizado = _seguroRepository.ListaPorId(_segurado.id);

                    //TODO: mapear em um metodo adequado
                    seguroLocalizado = new SeguroDto
                    {
                        segurado = _segurado,
                        veiculo = new VeiculoModel
                        {
                            Marca = dadosSeguroLocalizado.VeiculoMarca,
                            Modelo = dadosSeguroLocalizado.VeiculoModelo,
                            Valor = dadosSeguroLocalizado.VeiculoValor
                        }
                    };
                }
            }
            catch
            {
            }

            return seguroLocalizado;
        }
    }
}
