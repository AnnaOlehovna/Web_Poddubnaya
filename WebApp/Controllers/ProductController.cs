﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.DAL.Entities;
using WebApp.Extensions;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public List<Certificate> _certificates;
        List<CertificateGroup> _certificateGroups;

        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetUpData();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var certificatesFiltered = _certificates.Where(d => !group.HasValue || d.CertificateGroupId == group.Value);
            ViewData["Groups"] = _certificateGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Certificate>.GetModel(certificatesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }

        private void SetUpData()
        {
            _certificateGroups = new List<CertificateGroup>
            {
               new CertificateGroup { CertificateGroupId = 1, GroupName = "СПА"},
               new CertificateGroup { CertificateGroupId = 2, GroupName = "Квесты"},
               new CertificateGroup { CertificateGroupId = 3, GroupName = "Фотосессии"},
               new CertificateGroup { CertificateGroupId = 4, GroupName = "Экстрим"}
            };

            _certificates = new List<Certificate>
            {
                new Certificate{CertificateId = 1, CertificateName ="Аромауход «Горячая вишня»", Description = "Расслабляющий аромамассаж тела с прогреванием солевыми мешочками, глинтвейн;",
                Price = 60, CertificateGroupId = 1, Image = "spa gorachaya vishnya.jpg"},
                new Certificate{CertificateId = 2, CertificateName ="Живой квест с актерами «Затерянные души»", Description = "Квест с живыми актерами, который заставит Вас кричать от ужаса",
                Price = 90, CertificateGroupId = 2, Image = "kvest zateryanye dushi.jpg"},
                new Certificate{CertificateId = 3, CertificateName ="Семейная фотосессия", Description = "Семейная фотосессия: 1 час фотосессии, 40-50 обработанных фото, до 6 человек",
                Price = 99, CertificateGroupId = 3, Image = "fotosessia semeynaya.jpg"},
                new Certificate{CertificateId = 4, CertificateName ="SPA-комплекс для лица и тела «Секреты Клеопатры»", Description = "Скраб, обертывание, массаж головы, массаж тела, чай, 1 чел., 2 часа",
                Price = 135, CertificateGroupId = 1, Image = "spa secrety kleopatry.jpg"},
                new Certificate{CertificateId = 5, CertificateName ="Джип-трип", Description = "Lite trip, 2 машины, 2-6 человек, 1 час",
                Price = 158, CertificateGroupId = 4, Image = "extrim dzip trip.jpg"},
            };
        }
    }
}
