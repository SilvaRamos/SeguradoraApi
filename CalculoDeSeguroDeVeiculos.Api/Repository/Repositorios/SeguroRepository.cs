using CalculoDeSeguroDeVeiculos.Api.Model;
using CalculoDeSeguroDeVeiculos.Data;
using CalculoDeSeguroDeVeiculos.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CalculoDeSeguroDeVeiculos.Repository.Repositorios
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly DataContext _dbContext;

        public SeguroRepository(DataContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public List<SeguroModel> ListaTodos()
        {
            return _dbContext.Seguros.ToList();
        }
        //public List<SeguroModel> ListaPorCpf(string cpf)
        //{
        //    var result = _dbContext.Seguros.Where(x => x.CPFSegurado == cpf).Select( x =>
        //                    new SeguroModel
        //                    {
        //                        Id              = x.Id,

        //                        VeiculoMarca    = x.VeiculoMarca,
        //                        VeiculoModelo   = x.VeiculoModelo,
        //                        VeiculoValor    = x.VeiculoValor,
        //                        ValorSeguro     = x.ValorSeguro
        //                    }).ToList();

        //    return result;
        //}

        public SeguroModel ListaPorId(Guid idSegurado)
        {
            var result = _dbContext.Seguros.Where(x => x.SeguradoId == idSegurado).Select(x =>
                            new SeguroModel
                            {
                                Id = x.Id,
                                SeguradoId = x.SeguradoId,
                                VeiculoMarca = x.VeiculoMarca,
                                VeiculoModelo = x.VeiculoModelo,
                                VeiculoValor = x.VeiculoValor,
                                ValorSeguro = x.ValorSeguro
                            }).ToList();

            return result.FirstOrDefault();
        }

        //Lista os valores de todos os seguros registrados
        public List<Decimal> listaTodosOsValores()
        {
            return _dbContext.Seguros.Select(x => x.ValorSeguro).ToList();
        }
        public void Grava(SeguroModel seguro)
        {
            try
            {
                _dbContext.Seguros.Add(seguro);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();

            }
        }
    }
}
