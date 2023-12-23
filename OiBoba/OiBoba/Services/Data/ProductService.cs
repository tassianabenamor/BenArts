using OiBoba.DataAccessLayer;
using OiBoba.Models;
using Microsoft.EntityFrameworkCore;

namespace OiBoba.Services.Data;

public class ProductService : IProductService
{
    private AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public void Alterar(Product product)
    {
        var productEncontrado = Obter(product.ProductId);
        productEncontrado.Nome = product.Nome;
        productEncontrado.Descricao = product.Descricao;
        productEncontrado.Preco = product.Preco;
        productEncontrado.ImagemUri = product.ImagemUri;
        productEncontrado.EntregaExpressa = product.EntregaExpressa;
        productEncontrado.DataCadastro = product.DataCadastro;
        productEncontrado.MarcaId = product.MarcaId;
        productEncontrado.Categorias = product.Categorias;

        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var productEncontrado = Obter(id);
        _context.Product.Remove(productEncontrado);
        _context.SaveChanges();
    }

    public void Incluir(Product product)
    {
        _context.Product.Add(product);
        _context.SaveChanges();
    }

    public Product Obter(int id)
    {
        return _context.Product
                            .Include(item => item.Categorias)
                            .SingleOrDefault(item => item.ProductId == id);
    }

    public IList<Product> ObterTodos()
    {
        var resultado = _context.Product.ToList();
        return resultado;
    }

    public IList<Marca> ObterTodasMarcas()
        => _context.Marca.ToList();

    public Marca ObterMarca(int id)
        => _context.Marca.SingleOrDefault(item => item.MarcaId == id);

    public IList<Categoria> ObterTodasCategorias()
        => _context.Categoria.ToList();
}
