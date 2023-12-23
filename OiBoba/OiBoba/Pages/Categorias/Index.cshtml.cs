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
    public class IndexModel : PageModel
    {
        private readonly OiBoba.DataAccessLayer.AppDbContext _context;

        public IndexModel(OiBoba.DataAccessLayer.AppDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categoria { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categoria != null)
            {
                Categoria = await _context.Categoria.ToListAsync();
            }
        }
    }
}
