using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;
using SampleWebApi.Controllers;
using SampleWebApi.Model;
using SampleWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Tests.Controllers
{
    public class FabricanteControllerTests
    {
        [Fact]
        public async Task ShouldGetAllFabricante()
        {
            var mockRepository = new Mock<IFabricanteRepository>();

            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(
                new List<Fabricante>()
                {
                    new Fabricante()
                    {
                        DataFundacao = DateTime.Now,
                        Descricao = "Fabricante Dummy",
                        Id = Guid.NewGuid(),
                        Nome = "Teste",
                        Veiculos = []
                    }
                }

            );

            var controller = new FabricantesController(mockRepository.Object);

            var result = await controller.GetFabricantes();

            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.True(result.Value.Count() > 0);

        }

        [Fact]
        public async Task ShouldGetFabricanteByIdSuccessfully()
        {
            var mockRepository = new Mock<IFabricanteRepository>();
            var id = Guid.NewGuid();

            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(
                new Fabricante()
                {
                    Id = id,
                    DataFundacao = DateTime.Now,
                    Descricao = "Lorem Ipsum",
                    Nome = "Teste"
                });

            var controller = new FabricantesController(mockRepository.Object);

            var result = await controller.GetFabricante(id);

            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<Fabricante>(result.Value);
            Assert.True(result.Value.Id == id);

        }

        [Fact]
        public async Task ShouldGetFabricanteByIdAndReturnNotFound()
        {
            var mockRepository = new Mock<IFabricanteRepository>();
            var id = Guid.NewGuid();

            mockRepository.Setup(x => x.GetByIdAsync(id));

            var controller = new FabricantesController(mockRepository.Object);

            var result = (await controller.GetFabricante(id)).Result;

            Assert.NotNull(result);
            Assert.True((result as NotFoundResult).StatusCode == (int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task ShouldDeleteFabricanteByIdSuccessfully()
        {
            var mockRepository = new Mock<IFabricanteRepository>();
            var id = Guid.NewGuid();

            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(
               new Fabricante()
               {
                   Id = id,
                   DataFundacao = DateTime.Now,
                   Descricao = "Lorem Ipsum",
                   Nome = "Teste"
               });

            var controller = new FabricantesController(mockRepository.Object);

            var result = (await controller.DeleteFabricante(id));

            Assert.NotNull(result as NoContentResult);

        }

        [Fact]
        public async Task ShouldDeleteFabricanteByIdAndReturnNotFound()
        {
            var mockRepository = new Mock<IFabricanteRepository>();
            var id = Guid.NewGuid();

            mockRepository.Setup(x => x.GetByIdAsync(id));

            var controller = new FabricantesController(mockRepository.Object);

            var result = (await controller.GetFabricante(id)).Result;

            Assert.NotNull(result);
            Assert.True((result as NotFoundResult).StatusCode == (int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task ShouldPutFabricanteByIdAndReturnBadRequest()
        {
            var mockRepository = new Mock<IFabricanteRepository>();
            var id = Guid.NewGuid();
            var fabricanteUpdated = new Fabricante()
            {
                Id = Guid.NewGuid(),
            };

            var controller = new FabricantesController(mockRepository.Object);

            var result = (await controller.PutFabricante(id, fabricanteUpdated));

            Assert.NotNull(result);
            Assert.True((result as BadRequestResult).StatusCode == (int)HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task ShouldPutFabricanteByIdAndReturnSuccessfully()
        {
            var mockRepository = new Mock<IFabricanteRepository>();
            var id = Guid.NewGuid();
            var fabricanteUpdated = new Fabricante()
            {
                Id = id,
                DataFundacao = DateTime.Now,
                Descricao = "Loreim Ipsdum",
                Nome = "Testes",
            };

            mockRepository.Setup(x => x.UpdateAsync(fabricanteUpdated));

            var controller = new FabricantesController(mockRepository.Object);

            var result = (await controller.PutFabricante(id, fabricanteUpdated));

            Assert.NotNull(result);
            Assert.True((result as NoContentResult).StatusCode == (int)HttpStatusCode.NoContent);

        }

        [Fact]
        public async Task ShouldPostFabricanteByIdAndReturnSuccessfully()
        {
            var mockRepository = new Mock<IFabricanteRepository>();
            var fabricanteNew = new Fabricante()
            {
                Id = Guid.NewGuid(),
                DataFundacao = DateTime.Now,
                Descricao = "Loreim Ipsdum",
                Nome = "Testes",
            };
            mockRepository.Setup(x => x.SaveAsync(fabricanteNew));

            var controller = new FabricantesController(mockRepository.Object);

            var result = (await controller.PostFabricante(fabricanteNew)).Result;

            Assert.NotNull(result);
            Assert.True((result as CreatedAtActionResult).StatusCode == (int)HttpStatusCode.Created);
            Assert.True((result as CreatedAtActionResult).Value is Fabricante);

        }
    }
}
