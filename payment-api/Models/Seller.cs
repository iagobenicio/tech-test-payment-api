using System.ComponentModel.DataAnnotations;

namespace payment_api.Models
{
    public class Seller 
    {   
        
        [Required(ErrorMessage = "Vendedor precisa de um identificador")]
        public int Id { set; get; }

        [Required(ErrorMessage = "O campo CPF precisa ser válido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Name precisa ser válido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email precisa ser válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Phone precisa ser válido")]
        public string Phone { get; set; }

    }
}