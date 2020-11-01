using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using WebApp.Controllers;
using WebApp.DAL.Entities;
using Xunit;

namespace WebApp.Tests
{
    public class ProductControllerTests
    {

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            var controller = createProductController();
            controller._certificates = TestData.GetCertificatesList();
            // Act
            var result = controller.Index(pageNo: page, group: null) as ViewResult;
            var model = result?.Model as List<Certificate>;
            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].CertificateId);
        }

        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            var controller = createProductController();
            var data = TestData.GetCertificatesList();
            controller._certificates = data;
            var comparer = Comparer<Certificate>
            .GetComparer((c1, c2) => c1.CertificateId.Equals(c2.CertificateId));
            // act
            var result = controller.Index(2) as ViewResult;
            var model = result.Model as List<Certificate>;
            // assert
            Assert.Equal(2, model.Count);
            Assert.Equal(data[2], model[0], comparer);
        }

        private ProductController createProductController()
        {
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            return new ProductController() { ControllerContext = controllerContext };
        }
    }
}
