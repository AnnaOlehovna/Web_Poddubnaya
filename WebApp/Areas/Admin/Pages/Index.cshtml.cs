using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebApp.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Certificate> Certificate { get;set; }

        public async Task OnGetAsync()
        {
            Certificate = await _context.Certificates
                .Include(c => c.Group).ToListAsync();
        }
    }
}
