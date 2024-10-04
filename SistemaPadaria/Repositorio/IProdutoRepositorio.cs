using SistemaPadaria.Models;



public interface IProdutoRepositorio{


    ProdutoModel Adicionar(ProdutoModel Produto);

    List<ProdutoModel> BuscarProdutos();

    ProdutoModel ListarProduto(int codigoBarras);

    ProdutoModel Atualizar(ProdutoModel Produto);

    bool Remover(int codigoBarras);


}







