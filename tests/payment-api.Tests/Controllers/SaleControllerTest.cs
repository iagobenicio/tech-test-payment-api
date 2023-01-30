using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using payment_api.exceptions;
using payment_api.Models;
using payment_api.repositories;
using tech_test_payment_api.Controllers;


namespace payment_api.Tests.Controllers
{

    public class SaleControllerTest
    {
        Moq.Mock<ISalesRepository> repository = new Moq.Mock<ISalesRepository>();

        [Fact]
        public void GetSale_Controller()
        {   
            Sale sale = new Sale();
            sale.Id = 2;

            repository.Setup(x => x.GetSaleById(It.IsAny<int>())).Returns(sale);

            SaleController saleController = new SaleController(repository.Object);

            var result = saleController.GetSale(2);
            var objetResult = result as OkObjectResult; 
            
            Assert.NotNull(objetResult);
            var model = objetResult.Value as Models.Sale;

            Assert.NotNull(model);
            Assert.Equal(model.Id,2);
            
        }

        [Fact]
        public void GetSaleController_Return_InvalidSaleException()
        {   
            
            repository.Setup(x => x.GetSaleById(It.IsAny<int>())).Throws(new InvalidSaleException(2));

            SaleController saleController = new SaleController(repository.Object);

            var result = saleController.GetSale(2);

            Assert.Equal(result.GetType(),typeof(NotFoundObjectResult));

            var resultObject = result as NotFoundObjectResult;

            Assert.Equal(resultObject!.Value!.ToString(),$"Não foi encontrada uma venda com ID {2}");

        }

        [Fact]
        public void Should_UpdateStatusSale()
        {
            SaleController saleController = new SaleController(repository.Object);

            var result = saleController.UpdateSaleStatus(2,Status.Cancelada);

            Assert.Equal(result.GetType(),typeof(OkResult));

        }

        [Fact]
        public void UpdateSaleController_Return_InvalidTransitionException()
        {   
            const string erroMensage = "(algum erro de transição)";

            repository.Setup(x => x.UpdateSale(It.IsAny<Status>(),It.IsAny<int>())).Throws(new InvalidTransitionException(erroMensage));

            SaleController saleController = new SaleController(repository.Object);

            var result = saleController.UpdateSaleStatus(2,Status.AguardandoPagamento);

            Assert.Equal(result.GetType(),typeof(BadRequestObjectResult));

            var resultObject = result as BadRequestObjectResult;

            Assert.Equal(resultObject!.Value!.ToString(),$"Transição inválida: {erroMensage}");

        }

        [Fact]
        public void Shoud_RegisterSale()
        {
            SaleController saleController = new SaleController(repository.Object);

            Sale sale = new Sale();
            sale.Id = 2;

            var result = saleController.Register(sale);
            Assert.Equal(result.GetType(),typeof(CreatedAtActionResult));

            var objetResult = result as CreatedAtActionResult;
            var objectRouteValue = objetResult!.RouteValues!.First();

            Assert.Equal(objectRouteValue.Value,2);
        }

    }
}