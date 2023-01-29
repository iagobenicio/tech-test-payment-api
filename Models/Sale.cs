using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public Seller Seller { get; set; }
        public List<Item> Item { get; set; }
        public Status status { get; set; }
        public DateTime date {get; set;}

    }
}