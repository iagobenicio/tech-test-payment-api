using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers

{
    [ApiController]
    [Route("api-docs")]
    public class SaleController : ControllerBase
    {
        private List<Sale>? _sales = new List<Sale>();


        [HttpPost]
        public IActionResult Register(Sale sale)
        {   
            Console.WriteLine(sale!.Seller!.Name);
            if (sale == null)
            {
                return NotFound();
            }
            _sales!.Add(sale);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSale(int id)
        {
           var sale = _sales!.Where(item => item.Id == id).First();

            return Ok(sale);

        }

    }
}