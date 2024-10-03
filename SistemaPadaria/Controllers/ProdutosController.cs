using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaPadaria.Models;

namespace SistemaPadaria.Controllers;

public class ProdutosController : Controller
{

private readonly IProdutoRepositorio _produtoRepositorio;//fazendo a injeção de dependencia

    public ProdutosController(IProdutoRepositorio produtoRepositorio){

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
    public ActionResult CadastrarProduto(ProdutoModel produto)
    {
        _produtoRepositorio.Adicionar(produto);

        return RedirectToAction("CadastrarProduto"); //redireciona para index

    }






 public IActionResult Alterar()
    {
        return View();
    }

 public IActionResult Remover()
    {
        return View();
    }

 public IActionResult Listar()
    {
        return View();
    }

   
}
