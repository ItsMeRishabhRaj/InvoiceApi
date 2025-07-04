using Microsoft.AspNetCore.Mvc;
using InvoiceApi.Models;

namespace InvoiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        // In-memory data store (for now)
        private static List<Invoice> Invoices = new List<Invoice>();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> GetAll()
        {
            return Ok(Invoices);
        }

        [HttpGet("{id}")]
        public ActionResult<Invoice> GetById(int id)
        {
            var invoice = Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public ActionResult<Invoice> Create(Invoice invoice)
        {
            invoice.Id = _nextId++;
            Invoices.Add(invoice);
            return CreatedAtAction(nameof(GetById), new { id = invoice.Id }, invoice);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Invoice updated)
        {
            var invoice = Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return NotFound();

            invoice.CustomerName = updated.CustomerName;
            invoice.Amount = updated.Amount;
            invoice.Date = updated.Date;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var invoice = Invoices.FirstOrDefault(i => i.Id == id);
            if (invoice == null) return NotFound();

            Invoices.Remove(invoice);
            return NoContent();
        }
    }
}
