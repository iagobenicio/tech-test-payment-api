using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.repositories
{
    public class SaleRepositoryDataLocal : ISalesRepository
    {  

        private readonly List<Sale> _sales;

        public SaleRepositoryDataLocal()
        {   
            Console.WriteLine("aqui");
            _sales = new List<Sale>();
        }
        
        Sale ISalesRepository.GetSaleById(int id)
        {   
            var sale = _sales.Where(sale => sale.Id == id).First();
            return sale;
        }

        void ISalesRepository.RegisterSale(Sale sale)
        {   
            _sales.Add(sale);
        }

        void ISalesRepository.UpdateSale(Status status, int id)
        {
            var sale = _sales.Where(sale => sale.Id == id).First();

            sale.status = status;

        }
    }
}