using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using De_Kast.Data;
using De_Kast.Models;

namespace De_Kast.Pages.Personeel
{
    public class DeleteModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public DeleteModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Personeelslid Personeelslid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personeel == null)
            {
                return NotFound();
            }

            var personeelslid = await _context.Personeel.FirstOrDefaultAsync(m => m.ID == id);

            if (personeelslid == null)
            {
                return NotFound();
            }
            else 
            {
                Personeelslid = personeelslid;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Personeel == null)
            {
                return NotFound();
            }
            var personeelslid = await _context.Personeel.FindAsync(id);

            if (personeelslid != null)
            {
                Personeelslid = personeelslid;
                _context.Personeel.Remove(Personeelslid);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
