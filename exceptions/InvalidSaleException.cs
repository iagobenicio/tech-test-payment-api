using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.exceptions
{
    public class InvalidSaleException : Exception
    {
        private int _id;

        public InvalidSaleException(int id)
        {
            _id = id;
        }

        override
        public string ToString()
        {
            return $"Não foi encontrada uma venda com ID {_id}";
        }
    }
}