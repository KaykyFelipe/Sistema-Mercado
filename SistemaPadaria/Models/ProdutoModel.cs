using System.ComponentModel.DataAnnotations;
using SistemaPadaria.Repositorio;

namespace SistemaPadaria.Models
{
    
public class ProdutoModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o Codigo De Barras do Produto")]
    public string CodigoBarras { get; set; }

    [Required(ErrorMessage = "Digite o Nome do Produto")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o Valor do Produto")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Digite o Valor do Produto")]
    public decimal? Valor { get; set; }

    public EMedidaProduto MedidaProduto { get; set; }

    public string Descricao { get; set; }
    
  

    
    
    
    
    
    
}
}