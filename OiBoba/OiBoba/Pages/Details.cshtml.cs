using OiBoba.Models;
using OiBoba.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OiBoba.Pages
{
    public class DetailsModel : PageModel
    {
        private IProductService _service;
        public string DescricaoMarca { get; set; }

        public DetailsModel(IProductService service) 
        {
            _service = service;
        }

        public Product Product { get; private set; }

        public IActionResult OnGet(int id)
        {
            Product = _service.Obter(id);
            if (Product.MarcaId is not null)
            {
                DescricaoMarca = _service.ObterMarca(Product.MarcaId.Value).Descricao;
            }

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
