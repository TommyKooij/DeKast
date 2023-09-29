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

namespace De_Kast.Pages.Personeel
{
    public class EditModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public EditModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Personeelslid Personeelslid { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personeel == null)
            {
                return NotFound();
            }

            var personeelslid =  await _context.Personeel.FirstOrDefaultAsync(m => m.ID == id);
            if (personeelslid == null)
            {
                return NotFound();
            }
            Personeelslid = personeelslid;
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

            _context.Attach(Personeelslid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoneelslidExists(Personeelslid.ID))
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

        private bool PersoneelslidExists(int id)
        {
          return _context.Personeel.Any(e => e.ID == id);
        }
    }
}
