using SistemaPadaria.Repositorio;

namespace SistemaPadaria.Models
{
    
public class ProdutoModel
{
    public int Id { get; set; }
    public string CodigoBarras { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public EMedidaProduto MedidaProduto { get; set; }
    public string Descricao { get; set; }
    
  

    
    
    
    
    
    
}
}