namespace OiBoba.Models;

public class Marca
{
    public int MarcaId { get; set; }
    public string Descricao { get; set; }

    public ICollection<Product>? Products { get; set; }
}
