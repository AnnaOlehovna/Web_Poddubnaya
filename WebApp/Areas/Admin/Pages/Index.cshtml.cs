using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
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
