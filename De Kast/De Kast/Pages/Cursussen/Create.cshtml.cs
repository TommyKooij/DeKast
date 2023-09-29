using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using De_Kast.Data;
using De_Kast.Models;

namespace De_Kast.Pages.Cursussen
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
        public Cursus Cursus { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cursussen.Add(Cursus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
