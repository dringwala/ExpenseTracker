using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TrackerAPI.Models;
using TrackerDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackerAPI.Controllers
{
    [Route("api/[controller]")]
    public class BankController : TrackerControllerBase
    {
        

        public BankController(ITrackerRepository repo) : base(repo)
        {   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(TheRepository.GetAllBanks().OrderBy(b=> b.Name)
                                       .ToList()
                                       .Select(bank => TheModelFactory.Create(bank))) ;
        }

        [HttpGet("{id}", Name = "GetBank")]
        public IActionResult GetById(long id)
        {
            var item = TheRepository.GetBank(id);
            if (item == null)
                return NotFound();
            return Ok(TheModelFactory.Create(item));
        }

        [HttpGet("{bankName}", Name = "GetBankByName")]
        public IActionResult GetByBankName(string bankName)
        {
            var item = TheRepository.GetBankByName(bankName);
            if (item == null)
                return NotFound();
            return Ok(TheModelFactory.Create(item));
        }

        [HttpPost]
        public IActionResult Create([FromBody] BankModel bank)
        {
            if (bank == null)
                return BadRequest();

            var existingBank = TheRepository.GetBankByName(bank.Name);
            if (existingBank != null)
            {
                var existingBankModel = TheModelFactory.Create(existingBank);
                return Conflict(existingBankModel);
            }

            var entity = TheModelFactory.Parse(bank);
            TheRepository.Insert(entity);
            TheRepository.SaveAll();
            var model = TheModelFactory.Create(entity);
            return Ok(model);
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(long id, [FromBody] Bank bank)
        //{
        //    if (bank == null || bank.Id != id)
        //    {
        //        return BadRequest();
        //    }
        //    var bnk = _context.Banks.Find(id);
        //    if (bnk == null)
        //    {
        //        return NotFound();
        //    }
        //    bnk.Name = bank.Name;
        //    bnk.IsActive = bank.IsActive;
        //    bnk.RoutingNumber = bank.RoutingNumber;

        //    _context.Banks.Update(bnk);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

    }
}
