using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;

namespace WebApp.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            if (!context.CertificateGroups.Any())
            {
                context.CertificateGroups.AddRange(new List<CertificateGroup>
                {
               new CertificateGroup {  GroupName = "СПА"},
               new CertificateGroup { GroupName = "Квесты"},
               new CertificateGroup {  GroupName = "Фотосессии"},
               new CertificateGroup { GroupName = "Экстрим"}
            });
                await context.SaveChangesAsync();
            }
            if (!context.Certificates.Any())
            {
                context.Certificates.AddRange(new List<Certificate>
                {
                new Certificate{ CertificateName ="Аромауход «Горячая вишня»", Description = "Расслабляющий аромамассаж тела с прогреванием солевыми мешочками, глинтвейн;",
                Price = 60, CertificateGroupId = 1, Image = "spa gorachaya vishnya.jpg"},
                new Certificate{ CertificateName ="Живой квест с актерами «Затерянные души»", Description = "Квест с живыми актерами, который заставит Вас кричать от ужаса",
                Price = 90, CertificateGroupId = 2, Image = "kvest zateryanye dushi.jpg"},
                new Certificate{ CertificateName ="Семейная фотосессия", Description = "Семейная фотосессия: 1 час фотосессии, 40-50 обработанных фото, до 6 человек",
                Price = 99, CertificateGroupId = 3, Image = "fotosessia semeynaya.jpg"},
                new Certificate{ CertificateName ="SPA-комплекс для лица и тела «Секреты Клеопатры»", Description = "Скраб, обертывание, массаж головы, массаж тела, чай, 1 чел., 2 часа",
                Price = 135, CertificateGroupId = 1, Image = "spa secrety kleopatry.jpg"},
                new Certificate{ CertificateName ="Джип-трип", Description = "Lite trip, 2 машины, 2-6 человек, 1 час",
                Price = 158, CertificateGroupId = 4, Image = "extrim dzip trip.jpg"},
            });
                await context.SaveChangesAsync();
            }
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
