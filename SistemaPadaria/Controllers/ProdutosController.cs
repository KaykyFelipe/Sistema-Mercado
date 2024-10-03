using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaPadaria.Models;

namespace SistemaPadaria.Controllers;

public class ProdutosController : Controller
{
    public IActionResult GerenciarProdutos()
    {

        List <ProdutoModel> contatos = _contatoRepositorio.BuscarContatos();

        return View(contatos);

        
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
