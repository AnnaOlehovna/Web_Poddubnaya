using Microsoft.AspNetCore.Mvc;
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
            // Arrange
            var controller = new ProductController();
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
            var controller = new ProductController();
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
    }
}
