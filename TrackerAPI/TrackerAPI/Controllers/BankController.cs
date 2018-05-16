using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackerAPI.Controllers
{
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly TrackerContext _context;

        public BankController(TrackerContext context)
        {
            _context = context;

            if (_context.Banks.Count() == 0)
            {
                _context.Banks.Add(new Bank { Name = "Bank1", RoutingNumber = "012345678" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Bank> GetAlll()
        {
            return _context.Banks.ToList();
        }

        [HttpGet("{id}", Name = "GetBank")]
        public IActionResult GetById(long id)
        {
            var item = _context.Banks.Find(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Bank bank)
        {
            if (bank == null)
                return BadRequest();
            _context.Banks.Add(bank);
            _context.SaveChanges();

            return CreatedAtRoute("GetBank", new {id = bank.Id}, bank);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Bank bank)
        {
            if (bank == null || bank.Id != id)
            {
                return BadRequest();
            }
            var bnk = _context.Banks.Find(id);
            if (bnk == null)
            {
                return NotFound();
            }
            bnk.Name = bank.Name;
            bnk.IsActive = bank.IsActive;
            bnk.RoutingNumber = bank.RoutingNumber;

            _context.Banks.Update(bnk);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var bank = _context.Banks.Find(id);
            if (bank == null)
                return NotFound();
            _context.Banks.Remove(bank);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
