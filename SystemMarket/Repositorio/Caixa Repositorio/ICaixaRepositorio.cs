using SystemMarket.Models;

namespace SystemMarket.Repositorio
{
    public interface ICaixaRepositorio
    {
        ProdutoModel ListarProdutoPorCodigoBarras(string codigoBarras);
    }
}

