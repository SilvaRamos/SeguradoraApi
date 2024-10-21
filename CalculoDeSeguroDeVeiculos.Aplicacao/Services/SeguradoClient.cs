using CalculoDeSeguroDeVeiculos.Dominio.Models;
using RestSharp;

namespace CalculoDeSeguroDeVeiculos.Aplicacao.Services
{
    public class SeguradoClient
    {
        private readonly RestClient _restClient;

        public SeguradoClient()
        {
            const string urlApiSegurados = "http://localhost:3000";

            _restClient = new RestClient(urlApiSegurados);
        }

        public List<SeguradoModel> buscaSeguradoPorCpf(string cpf)
        {
            var request = new RestRequest(resource:"segurados")
                .AddParameter("cpf", cpf);

            var segurados = _restClient.Get<List<SeguradoModel>>(request);

            return segurados!;
        }

        public SeguradoModel buscaSegurado(Guid id)
        {
            var request = new RestRequest(resource: "segurados")
                .AddParameter("id", id);

            List<SeguradoModel> segurados = _restClient.Get<List<SeguradoModel>>(request);

            SeguradoModel segurado = segurados.FirstOrDefault();

            return segurado;
        }

        public SeguradoModel gravaSegurado(SeguradoModel segurado)
        {
            var result = false;
            segurado.id = Guid.NewGuid();

            var request = new RestRequest(resource: "segurados")
                .AddJsonBody(segurado);

            var seguradoAdicionado = _restClient.Post<SeguradoModel>(request);

            //if( !string.IsNullOrEmpty(seguradoAdicionado!.CPF) )
            //{
            //    result = true;
            //}

            return seguradoAdicionado;
        }
    }
}
