using System.ComponentModel.DataAnnotations;

namespace payment_api.Models
{
    public class Item
    {   
        [Required(ErrorMessage = "O item deve conter um nome")]
        public string Name { get; set; }
    }
}