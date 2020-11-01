using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;
using WebApp.Extensions;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;

        int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var certificatesFiltered = _context.Certificates.Where(d => !group.HasValue || d.CertificateGroupId == group.Value);
            ViewData["Groups"] = _context.CertificateGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Certificate>.GetModel(certificatesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
