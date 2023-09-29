using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using De_Kast.Data;
using De_Kast.Models;

namespace De_Kast.Pages.Abonnementen
{
    public class EditModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public EditModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Abonnement Abonnement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }

            var abonnement =  await _context.Abonnementen.FirstOrDefaultAsync(m => m.ID == id);
            if (abonnement == null)
            {
                return NotFound();
            }
            Abonnement = abonnement;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Abonnement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonnementExists(Abonnement.ID))
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

        private bool AbonnementExists(int id)
        {
          return _context.Abonnementen.Any(e => e.ID == id);
        }
    }
}
