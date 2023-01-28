using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Status
    {

        public virtual string SaleStatus()
        {
            return "Aguardando Pagamento";
        }

    }

    public class PaymentAccept : Status
    {   
        override
        public string SaleStatus()
        {
            return "Pagamento Aprovado";
        }
    }

    public class Shipping : Status
    {   
        override
        public string SaleStatus()
        {
            return "Enviado Para Transportadora";
        }

    }

    public class Delivered : Status
    {   
        override
        public string SaleStatus()
        {
            return "Entregue";
        }

    }

    public class Canceled : Status
    {   
        override
        public string SaleStatus()
        {
            return "Cancelado";
        }
    }




}