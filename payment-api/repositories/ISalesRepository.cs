using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using payment_api.Models;

namespace payment_api.repositories
{
    public interface ISalesRepository
    {
        public void RegisterSale(Sale sale);
        public Sale GetSaleById(int id);
        public void UpdateSale(Status status, int id);
    }
}