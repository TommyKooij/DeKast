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
    public class IndexModel : PageModel
    {
        private readonly De_Kast.Data.ApplicationDbContext _context;

        public IndexModel(De_Kast.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Abonnement> Abonnement { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Abonnementen != null)
            {
                Abonnement = await _context.Abonnementen.ToListAsync();
            }
        }
    }
}
