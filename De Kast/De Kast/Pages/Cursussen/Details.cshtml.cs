using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using De_Kast.Data;
using De_Kast.Models;

namespace De_Kast.Pages.Cursussen
{
    public class DetailsModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public DetailsModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Cursus Cursus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursussen == null)
            {
                return NotFound();
            }

            var cursus = await _context.Cursussen.FirstOrDefaultAsync(m => m.ID == id);
            if (cursus == null)
            {
                return NotFound();
            }
            else 
            {
                Cursus = cursus;
            }
            return Page();
        }
    }
}
