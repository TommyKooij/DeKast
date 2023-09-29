using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using De_Kast.Data;
using De_Kast.Models;

namespace De_Kast.Pages.Abonnementen
{
    public class DetailsModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public DetailsModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Abonnement Abonnement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }

            var abonnement = await _context.Abonnementen.FirstOrDefaultAsync(m => m.ID == id);
            if (abonnement == null)
            {
                return NotFound();
            }
            else 
            {
                Abonnement = abonnement;
            }
            return Page();
        }
    }
}
