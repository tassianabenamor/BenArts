using OiBoba.Models;

namespace OiBoba.Services;

public interface IProductService
{
    IList<Product> ObterTodos();
    Product Obter(int id);
    void Incluir(Product product);
    void Alterar(Product product);
    void Excluir(int id);
    IList<Marca> ObterTodasMarcas();
    Marca ObterMarca(int id);
    IList<Categoria> ObterTodasCategorias();
}
