using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.exceptions
{
    public class InvalidTransitionException : Exception
    {
        private string _mensage; 
        public InvalidTransitionException(string erroMensage)
        {
            _mensage = erroMensage;
        }

        override 
        public string ToString()
        {
            return $"Transição inválida: {_mensage}";
        }
    }
}