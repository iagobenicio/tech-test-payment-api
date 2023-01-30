using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using payment_api.repositories;
using Moq;
using payment_api.Models;
using payment_api.exceptions;

namespace payment_api.Tests.repositories
{

    public class SaleRepositoryDataLocalTest
    {   
        Moq.Mock<List<Item>> mockItem = new Mock<List<Item>>();
        Moq.Mock<Seller> mockSeller = new Mock<Seller>();


        [Fact]
        public void Get_Sale_By_Id_2()
        {   
            var sale = new Sale();

            List<Sale> sales = new List<Sale>();
            sale.Id = 2;
            sale.Item = mockItem.Object;
            sale.Seller = mockSeller.Object;
            sale.Date = DateTime.Now;
            sale.Status = Status.AguardandoPagamento;

            sales.Add(sale);

            var saleRepository = new SaleRepositoryDataLocal(sales);
            
            var saleResult = saleRepository.GetSaleById(2);

            Assert.Equal(saleResult.Id,sale.Id);

        }

        [Fact]
        public void Should_Return_InvalidSaleException()
        {

            List<Sale> sales = new List<Sale>();

            var saleRepository = new SaleRepositoryDataLocal(sales);

            var result = Assert.Throws<InvalidSaleException>(() => saleRepository.GetSaleById(2));


            Assert.Equal(result.ToString(),$"Não foi encontrada uma venda com ID {2}");

        }    

        [Fact]
        public void Register_Sale_To_List()
        {   
            var sale = new Sale();
            sale.Id = 2;
            sale.Item = mockItem.Object;
            sale.Seller = mockSeller.Object;
            sale.Date = DateTime.Now;
            sale.Status = Status.AguardandoPagamento;

            List<Sale> sales = new List<Sale>();

            var saleRepository = new SaleRepositoryDataLocal(sales);

            saleRepository.RegisterSale(sale);

            Assert.NotEmpty(sales);
        }

        [Fact]
        public void Sale_Should_Register_With_Status_AguardandoPagamento()
        {   
            var sale = new Sale();
            sale.Id = 2;
            sale.Item = mockItem.Object;
            sale.Seller = mockSeller.Object;
            sale.Date = DateTime.Now;
            sale.Status = Status.Cancelada;

            List<Sale> sales = new List<Sale>();

            var saleRepository = new SaleRepositoryDataLocal(sales);

            saleRepository.RegisterSale(sale);

            Assert.Equal(sales[0].Status,Status.AguardandoPagamento);
        }

        
        [Fact]
        public void Update_Status_Sale_From_AguardandoPagamento_To_Cancelada()
        {
            var sale = new Sale();
            sale.Id = 2;
            sale.Item = mockItem.Object;
            sale.Seller = mockSeller.Object;
            sale.Date = DateTime.Now;
            sale.Status = Status.AguardandoPagamento;

            List<Sale> sales = new List<Sale>();

            sales.Add(sale);

            var saleRepository = new SaleRepositoryDataLocal(sales);

            saleRepository.UpdateSale(Status.Cancelada,2);

            Assert.Equal(sales[0].Status,Status.Cancelada);

        }

        [Fact]
        public void Update_Sale_Status_Should_Be_AguardandoPagamento_Or_Cancelada()
        {
            
            var sale = new Sale();
            sale.Id = 2;
            sale.Item = mockItem.Object;
            sale.Seller = mockSeller.Object;
            sale.Date = DateTime.Now;
            sale.Status = Status.AguardandoPagamento;

            List<Sale> sales = new List<Sale>();

            sales.Add(sale);

            var saleRepository = new SaleRepositoryDataLocal(sales);
            
            var result = Assert.Throws<InvalidTransitionException>(() => saleRepository.UpdateSale(Status.Entregue,2));

            var mensage = $"o status só pode ser alterado para {Status.PagamentoAprovado} ou {Status.Cancelada}";
            Assert.Equal(result.ToString(),$"Transição inválida: {mensage}");
        
        }

        [Fact]
        public void Update_Status_Sale_From_PagamentoAprovado_To_EnviadoParaTransportadora()
        {
            var sale = new Sale();
            sale.Id = 2;
            sale.Item = mockItem.Object;
            sale.Seller = mockSeller.Object;
            sale.Date = DateTime.Now;
            sale.Status = Status.PagamentoAprovado;

            List<Sale> sales = new List<Sale>();

            sales.Add(sale);

            var saleRepository = new SaleRepositoryDataLocal(sales);

            saleRepository.UpdateSale(Status.EnviadoParaTransportadora,2);

            Assert.Equal(sales[0].Status,Status.EnviadoParaTransportadora);

        }

        [Fact]
        public void Update_Status_Sale_From_EnviadoParaTransportadora_To_Entregue()
        {
            var sale = new Sale();
            sale.Id = 2;
            sale.Item = mockItem.Object;
            sale.Seller = mockSeller.Object;
            sale.Date = DateTime.Now;
            sale.Status = Status.EnviadoParaTransportadora;

            List<Sale> sales = new List<Sale>();

            sales.Add(sale);

            var saleRepository = new SaleRepositoryDataLocal(sales);

            saleRepository.UpdateSale(Status.Entregue,2);

            Assert.Equal(sales[0].Status,Status.Entregue);

        }

    }
}