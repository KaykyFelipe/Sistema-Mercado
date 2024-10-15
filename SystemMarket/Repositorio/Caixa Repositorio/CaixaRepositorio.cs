using SystemMarket.Configuration;
using SystemMarket.Models;

namespace SystemMarket.Repositorio
{
    public class CaixaRepositorio : ICaixaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CaixaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel ListarProdutoPorCodigoBarras(string codigoBarras)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.CodigoBarras == codigoBarras);
        }
    }
}








