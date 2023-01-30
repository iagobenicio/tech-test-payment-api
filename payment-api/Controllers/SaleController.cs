using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using payment_api.exceptions;
using payment_api.Models;
using payment_api.repositories;

namespace tech_test_payment_api.Controllers

{
    [ApiController]
    [Route("api-docs")]
    public class SaleController : ControllerBase
    {
        private readonly ISalesRepository _repository;

        public SaleController(ISalesRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("sales")]
        public IActionResult Register(Sale sale)
        {   
  
            _repository.RegisterSale(sale);
            return CreatedAtAction(nameof(GetSale), new {id = sale.Id}, sale);

        }

        [HttpGet("sales/{id}")]
        public IActionResult GetSale(int id)
        {

            try
            {
                var sale = _repository.GetSaleById(id);
                return Ok(sale);
            }
            catch (InvalidSaleException e)
            {
                return NotFound(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }

        [HttpPatch("/sales/{id}/{status}")]
        public IActionResult UpdateSaleStatus(int id, Status status)
        {
            try
            {
                _repository.UpdateSale(status,id);
                return Ok();
            }
            catch (InvalidTransitionException e)
            {
                return BadRequest(e.ToString());
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

    }
}