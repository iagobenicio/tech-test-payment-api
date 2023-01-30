using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.exceptions;
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
        
        public Sale GetSaleById(int id)
        {     
            var sale = _sales.Find(x => x.Id == id);
            if (sale == null)
            {
                throw new InvalidSaleException(id);
            }
            return sale;
        }

        public void RegisterSale(Sale sale)
        {   
            if (sale.status != Status.AguardandoPagamento)
            {
                sale.status = Status.AguardandoPagamento;
            }
            _sales.Add(sale);
        }

        public void UpdateSale(Status status, int id)
        {
            var sale = GetSaleById(id);

            if (status != sale.status)
            {
                switch (sale.status)
                {
                    case Status.AguardandoPagamento:

                        if (!(status == Status.PagamentoAprovado || status == Status.Cancelada))
                        {
                            throw new InvalidTransitionException($"o status só pode ser alterado para {Status.PagamentoAprovado} ou {Status.Cancelada}");
                        }

                        sale.status = status;
                        break;
                    case Status.PagamentoAprovado:

                        if (!(status == Status.Cancelada || status == Status.EnviadoParaTransportadora))
                        {
                            throw new InvalidTransitionException($"o status só pode ser alterado para {Status.Cancelada} ou {Status.EnviadoParaTransportadora}");
                        }
                        sale.status = status;
                        break;
                    case Status.EnviadoParaTransportadora:

                        if (!(status == Status.Entregue))
                        {
                            throw new InvalidTransitionException($"o status só pode ser alterado para {Status.Entregue}");
                        }
                        sale.status = status;
                        break;
                }
            }
        }
    }
}