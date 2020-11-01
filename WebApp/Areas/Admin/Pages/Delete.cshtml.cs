using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.DAL.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(WebApp.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Certificate = await _context.Certificates.FindAsync(id);

            if (Certificate != null)
            {
                _context.Certificates.Remove(Certificate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
