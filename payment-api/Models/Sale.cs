using System.ComponentModel.DataAnnotations;

namespace payment_api.Models
{
    public class Sale
    {

        [Required(ErrorMessage = "Venda precisa de um identificador")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Uma venda deve conter um vendedor")]
        public Seller Seller { get; set; }

        [MinLength(1,ErrorMessage = "A venda precisa possuir pelo menos 1 (um) item")]
        public List<Item> Item { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime Date {get; set;}

    }
}