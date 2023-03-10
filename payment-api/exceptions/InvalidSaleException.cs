namespace payment_api.exceptions
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