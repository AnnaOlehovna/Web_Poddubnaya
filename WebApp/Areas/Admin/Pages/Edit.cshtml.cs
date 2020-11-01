using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public EditModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Certificate Certificate { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

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
            ViewData["CertificateGroupId"] = new SelectList(_context.CertificateGroups, "CertificateGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Certificate).State = EntityState.Modified;

            if (Image != null)
            {
                var fileName = $"{Certificate.CertificateId}" + Path.GetExtension(Image.FileName);
                Certificate.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(Certificate.CertificateId))
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

        private bool CertificateExists(int id)
        {
            return _context.Certificates.Any(e => e.CertificateId == id);
        }
    }
}
