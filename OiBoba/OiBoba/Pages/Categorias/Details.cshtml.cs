using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OiBoba.DataAccessLayer;
using OiBoba.Models;

namespace OiBoba.Pages.Categorias
{
    public class DetailsModel : PageModel
    {
        private readonly OiBoba.DataAccessLayer.AppDbContext _context;

        public DetailsModel(OiBoba.DataAccessLayer.AppDbContext context)
        {
            _context = context;
        }

      public Categoria Categoria { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }
            else 
            {
                Categoria = categoria;
            }
            return Page();
        }
    }
}
