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
    public class DetailsModel : PageModel
    {
        private readonly WebApp.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Certificate Certificate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Certificate = await _context.Certificates
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.CertificateId == id);

            if (Certificate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
