using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SystemMarket.Models;

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

    public IActionResult AtualizarProduto()
    {

        return View();
    }



    [HttpPost]
    public ActionResult CadastrarProduto(ProdutoModel produto)
    {
        if (produto.Valor == null || string.IsNullOrEmpty(produto.CodigoBarras) || string.IsNullOrEmpty(produto.Nome))
        {
            ModelState.AddModelError("CamposObrigatorios", "Campos obrigatórios não preenchidos.");
            return View(produto);
        }

        _produtoRepositorio.Adicionar(produto);
        return RedirectToAction("GerenciarProdutos");
    }


    public IActionResult EditarProduto(int id)
{
    ProdutoModel produto = _produtoRepositorio.ListarProduto(id);
    return View(produto);
}

    [HttpPost]
    public IActionResult AtualizarProduto(ProdutoModel produto)
    {

         if (produto.Valor == null || string.IsNullOrEmpty(produto.CodigoBarras) || string.IsNullOrEmpty(produto.Nome))
        {
            ModelState.AddModelError("CamposObrigatorios", "Campos obrigatórios não preenchidos.");
            return View("EditarProduto");
        }

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



