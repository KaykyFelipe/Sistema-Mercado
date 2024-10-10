using SistemaPadaria.Models;

namespace SistemaPadaria.Repositorio
{
    public interface ICaixaRepositorio
    {
        ProdutoModel ListarProdutoPorCodigoBarras(string codigoBarras);
    }
}

