using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace tech_test_payment_api.Models
{
    public class Item
    {   
        [Required(ErrorMessage = "O item deve conter um nome")]
        public string Name { get; set; }
    }
}