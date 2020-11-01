using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using WebApp.Controllers;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;
using Xunit;

namespace WebApp.Tests
{
    public class ProductControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests()
        {
            _options =
            new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "testDb")
            .Options;
        }

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = createProductController(context);
                var result = controller.Index(group: null, pageNo:page) as ViewResult;
                var model = result?.Model as List<Certificate>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].CertificateId);
            };

            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public void ControllerSelectsGroup()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = createProductController(context);
                var comparer = Comparer<Certificate>.GetComparer((d1, d2) => d1.CertificateId.Equals(d2.CertificateId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Certificate>;
                // assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.Certificates.ToArrayAsync().GetAwaiter().GetResult()[2], model[0], comparer);
            }
        }

        private ProductController createProductController(ApplicationDbContext context)
        {
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            return new ProductController(context) { ControllerContext = controllerContext };
        }
    }
}
