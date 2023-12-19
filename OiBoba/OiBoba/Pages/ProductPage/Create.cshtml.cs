using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OiBoba.Models;
using OiBoba.Services.FileUploadService;

namespace OiBoba.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly OiBoba.DataAccessLayer.AppDbContext _context;
        private readonly IFileUploadService fileUploadService;

        public CreateModel(OiBoba.DataAccessLayer.AppDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            this.fileUploadService = fileUploadService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile fileToUpload)
        {
          if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }
            var fileName = "";
          if(fileToUpload != null)
            {
                fileName = await fileUploadService.UploadFileAsync(fileToUpload);
            }
           
            Product.Midia = fileName;
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
