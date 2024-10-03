using SistemaPadaria.Models;



public interface IProdutoRepositorio{


    ProdutoModel Adicionar(ProdutoModel Produto);

    List<ProdutoModel> BuscarProdutos();

    ProdutoModel ListarId(string codigoBarras);

    ProdutoModel Atualizar(ProdutoModel Produto);

    bool Remover(string codigoBarras);


}







