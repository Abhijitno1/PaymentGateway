using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Models;

namespace PaymentGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/Payment")]
    public class PaymentController : Controller
    {
        private PaymentDbContext dbContext;

        public PaymentController(PaymentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Payment
        [HttpGet]
        public IActionResult GetAllPaymentsList()
        {
            //ToDo: Include exception scenarios
            var payments = dbContext.Payments.OrderByDescending(pymt => pymt.TransactionDate).ToList();
            return Ok(payments);
        }

        // GET: api/FindPayments
        [HttpPost("FindPayments")]
        public IActionResult FindPayments([FromBody]Payment searchPayment)
        {
            //ToDo: Search value in DB
            //ToDo: Include exception scenarios
            var searchResults = new[] { searchPayment };
            return Ok(searchResults);
        }
        
        // POST: api/MakePayment
        [HttpPost("MakePayment")]
        public IActionResult MakePayment([FromBody]Payment newPayment)
        {
            //ToDo: Include exception scenarios
            dbContext.Payments.Add(newPayment);
            dbContext.SaveChanges();
            return NoContent();
        }

    }
}
