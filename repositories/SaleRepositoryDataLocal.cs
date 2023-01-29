using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.repositories
{
    public class SaleRepositoryDataLocal : ISalesRepository
    {
        Sale ISalesRepository.GetSaleById(int id)
        {
            throw new NotImplementedException();
        }

        void ISalesRepository.RegisterSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        void ISalesRepository.UpdateSale(Status status, int id)
        {
            throw new NotImplementedException();
        }
    }
}