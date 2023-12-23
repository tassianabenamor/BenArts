using Microsoft.AspNetCore.Mvc.RazorPages;
using OiBoba.Models;
using OiBoba.Services;

public class IndexModel : PageModel
{
    private IProductService _service;

    public IndexModel(IProductService service)
    {
        _service = service;
    }

    public IList<Product> ListaProduct { get; private set; }

    public void OnGet()
    {
        ViewData["Title"] = "Home page";

        ListaProduct = _service.ObterTodos();
    }
}