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

namespace De_Kast.Pages.Cursussen
{
    public class EditModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public EditModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cursus Cursus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursussen == null)
            {
                return NotFound();
            }

            var cursus =  await _context.Cursussen.FirstOrDefaultAsync(m => m.ID == id);
            if (cursus == null)
            {
                return NotFound();
            }
            Cursus = cursus;
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

            _context.Attach(Cursus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursusExists(Cursus.ID))
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

        private bool CursusExists(int id)
        {
          return _context.Cursussen.Any(e => e.ID == id);
        }
    }
}
