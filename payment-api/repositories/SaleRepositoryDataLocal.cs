using payment_api.exceptions;
using payment_api.Models;

namespace payment_api.repositories
{
    public class SaleRepositoryDataLocal : ISalesRepository
    {  

        private readonly List<Sale> _sales;

        public SaleRepositoryDataLocal(List<Sale> sales)
        {   
            _sales = sales;
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
            if (sale.Status != Status.AguardandoPagamento)
            {
                sale.Status = Status.AguardandoPagamento;
            }
            _sales.Add(sale);
        }

        public void UpdateSale(Status status, int id)
        {
            var sale = GetSaleById(id);

            if (status != sale.Status)
            {
                switch (sale.Status)
                {
                    case Status.AguardandoPagamento:

                        if (!(status == Status.PagamentoAprovado || status == Status.Cancelada))
                        {
                            throw new InvalidTransitionException($"o status só pode ser alterado para {Status.PagamentoAprovado} ou {Status.Cancelada}");
                        }

                        sale.Status = status;
                        break;
                    case Status.PagamentoAprovado:

                        if (!(status == Status.Cancelada || status == Status.EnviadoParaTransportadora))
                        {
                            throw new InvalidTransitionException($"o status só pode ser alterado para {Status.Cancelada} ou {Status.EnviadoParaTransportadora}");
                        }
                        sale.Status = status;
                        break;
                    case Status.EnviadoParaTransportadora:

                        if (!(status == Status.Entregue))
                        {
                            throw new InvalidTransitionException($"o status só pode ser alterado para {Status.Entregue}");
                        }
                        sale.Status = status;
                        break;
                }
            }
        }
    }
}