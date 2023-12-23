using OiBoba.Models;

namespace OiBoba.Services.Memory;

public class ProductService : IProductService
{
    public ProductService()
        => CarregarListaInicial();

    private IList<Product> _products;

    private void CarregarListaInicial()
    {
        _products = new List<Product>()
        {
            new Product
            {
                ProductId = 1,
                Nome = "Print 1",
                Descricao = "Descrição do produto!",
                ImagemUri = "/images/arte1.jpg",
                Preco = 19.00,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Product
            {
                ProductId = 2,
                Nome = "Print 2",
                Descricao = "Descrição do produto!",
                ImagemUri = "/images/arte2.jpg",
                Preco = 29.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
            new Product
            {
                ProductId = 3,
                Nome = "Print 3",
                Descricao = "Descrição do produto!",
                ImagemUri = "/images/arte3.jpg",
                Preco = 39.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
            new Product
            {
                ProductId = 4,
                Nome = "Print 4",
                Descricao = "Descrição do produto!",
                ImagemUri = "/images/arte4.jpg",
                Preco = 159.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
        };
    }

    public IList<Product> ObterTodos()
        => _products;

    public Product Obter(int id)
        => ObterTodos().SingleOrDefault(item => item.ProductId == id);

    public void Incluir(Product product)
    {
        var proximoId = _products.Max(item => item.ProductId) + 1;
        product.ProductId = proximoId;
        _products.Add(product);
    }

    public void Alterar(Product product)
    {
        var productEncontrado = _products.SingleOrDefault(item => item.ProductId == product.ProductId);
        productEncontrado.Nome = product.Nome;
        productEncontrado.Descricao = product.Descricao;
        productEncontrado.Preco = product.Preco;
        productEncontrado.EntregaExpressa = product.EntregaExpressa;
        productEncontrado.DataCadastro = product.DataCadastro;
        productEncontrado.ImagemUri = product.ImagemUri;
    }

    public void Excluir(int id)
    {
        var productEncontrado = Obter(id);
        _products.Remove(productEncontrado);
    }

    public IList<Marca> ObterTodasMarcas()
    {
        throw new NotImplementedException();
    }

    public Marca ObterMarca(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Categoria> ObterTodasCategorias()
    {
        throw new NotImplementedException();
    }
}
