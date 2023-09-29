using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using De_Kast.Data;
using De_Kast.Models;

namespace De_Kast.Pages.Personeel
{
    public class CreateModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public CreateModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Personeelslid Personeelslid { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Personeel.Add(Personeelslid);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
