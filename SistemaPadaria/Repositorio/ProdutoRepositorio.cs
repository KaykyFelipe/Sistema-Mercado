using SistemaPadaria.Configuration;

using SistemaPadaria.Models;

namespace SistemaPadaria.Repositorio
{

public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;


        public ProdutoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public ProdutoModel Adicionar(ProdutoModel produtos)
        {
           _bancoContext.Set<ProdutoModel>().Add(produtos); //salvar no banco de dados 
           _bancoContext.SaveChanges();  

           return produtos;
        }

        public List<ProdutoModel> BuscarProdutos()
        {
            return _bancoContext.Set<ProdutoModel>().ToList();
        }

        public ProdutoModel ListarId(string codigoBarras)
        {
            return _bancoContext.Set<ProdutoModel>().FirstOrDefault(x => x.CodigoBarras == codigoBarras);
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarId(produto.CodigoBarras);

            if(produtoDB == null)throw new Exception("Houve um erro na atualização do produto!!");

            produtoDB.Nome = produto.Nome;
            produtoDB.Valor = produto.Valor;
            produtoDB.MedidaProduto = produto.MedidaProduto; //medida é um enum

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();

            return produtoDB; 


            
        }

        public bool Remover(string codigoBarras)
        {
            ProdutoModel produtoDB = ListarId(codigoBarras);

            if(produtoDB == null)throw new Exception("Houve um erro na Remoção do produto!!");

            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();
            
            return true;


            
        }

       
    }









}