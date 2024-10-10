using Microsoft.AspNetCore.Mvc;
using SistemaPadaria.Repositorio;

namespace SistemaPadaria.Controllers
{
    public class CaixaController : Controller
    {
        private readonly ICaixaRepositorio _caixaRepositorio;

        public CaixaController(ICaixaRepositorio caixaRepositorio)
        {
            _caixaRepositorio = caixaRepositorio;
        }

        public IActionResult Caixa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarProdutoCaixa(string codigoBarras)
        {
            var produto = _caixaRepositorio.ListarProdutoPorCodigoBarras(codigoBarras);
            if (produto == null)
            {
                return Json(null);
            }

            return Json(new
            {
                codigoBarras = produto.CodigoBarras,
                nome = produto.Nome,
                valor = produto.Valor,
                medida = produto.MedidaProduto.ToString()
            });
        }
    }
}
