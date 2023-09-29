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
    public class DeleteModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public DeleteModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }
            var abonnement = await _context.Abonnementen.FindAsync(id);

            if (abonnement != null)
            {
                Abonnement = abonnement;
                _context.Abonnementen.Remove(Abonnement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
