using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OiBoba.Models;
using OiBoba.Services.FileUploadService;

namespace OiBoba.Pages.ProductPage
{
    public class EditModel : PageModel
    {
        private readonly OiBoba.DataAccessLayer.AppDbContext _context;
        private readonly IFileUploadService fileUploadService;

        public EditModel(OiBoba.DataAccessLayer.AppDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            this.fileUploadService = fileUploadService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product =  await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile fileToUpload)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var fileName = "";
            if (fileToUpload != null)
            {
                fileName = await fileUploadService.UploadFileAsync(fileToUpload);
            }

            Product.Midia = fileName;

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(Guid id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
