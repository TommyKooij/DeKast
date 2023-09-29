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
    public class IndexModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public IndexModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Personeelslid> Personeelslid { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Personeel != null)
            {
                Personeelslid = await _context.Personeel.ToListAsync();
            }
        }
    }
}
