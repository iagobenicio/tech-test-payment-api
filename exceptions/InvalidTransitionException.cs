using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.exceptions
{
    public class InvalidTransitionException : Exception
    {
        public InvalidTransitionException(string erroMensage)
        {

        }
    }
}