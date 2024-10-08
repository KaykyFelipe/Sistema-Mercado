using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaPadaria.Models;

namespace SistemaPadaria.Controllers;

public class ProdutosController : Controller
{

    private readonly IProdutoRepositorio _produtoRepositorio;//fazendo a injeção de dependencia

    public ProdutosController(IProdutoRepositorio produtoRepositorio)
    {

        _produtoRepositorio = produtoRepositorio;
    }


    public IActionResult GerenciarProdutos()
    {


        List<ProdutoModel> produtos = _produtoRepositorio.BuscarProdutos();


        return View(produtos);

    }

    public IActionResult CadastrarProduto()
    {

        return View();
    }


    [HttpPost]
    public ActionResult CadastrarProduto(ProdutoModel produto)//METODO
    {
        _produtoRepositorio.Adicionar(produto);

        return RedirectToAction("CadastrarProduto"); //redireciona para index

    }

  public IActionResult EditarProduto(int id)
{
    ProdutoModel produto = _produtoRepositorio.ListarProduto(id);
    return View(produto);
}

    [HttpPost]
    public IActionResult AtualizarProduto(ProdutoModel produto)
    {
        _produtoRepositorio.Atualizar(produto);

        return RedirectToAction("GerenciarProdutos");
    }


  
    public IActionResult RemoverProduto(int id)
    {
      ProdutoModel produto = _produtoRepositorio.ListarProduto(id);   
        return View(produto);
    }

     public IActionResult Remover(int id)
    {
         _produtoRepositorio.Remover(id);

        return RedirectToAction("GerenciarProdutos"); //redireciona para index

    }
    

}



