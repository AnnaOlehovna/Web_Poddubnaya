using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;

namespace WebApp.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["CertificateGroupId"] = new SelectList(_context.CertificateGroups, "CertificateGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Certificate Certificate { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                var fileName = $"{Certificate.CertificateId}" + Path.GetExtension(Image.FileName);
                Certificate.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }
            _context.Certificates.Add(Certificate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
