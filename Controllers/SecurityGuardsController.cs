using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Chop.Models;

namespace TomaToma.Controllers
{
    [ApiController]
    [Route("/SecurityGuards")]
    public class SecurityGuardController : Controller
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            var db = new ChopContext();
            return Ok(db.SecurityGuards);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var db = new ChopContext();
            var segu = db.SecurityGuards.SingleOrDefault(s => s.Id == id);
            if (segu == null)
                return NotFound();
            return Ok(segu);
        }
        [HttpPost]
        public IActionResult Add(SecurityGuard securityguard)
        {
            var db = new ChopContext();
            db.SecurityGuards.Add(securityguard);
            db.SaveChanges();
            return Ok(securityguard);
        }
        [HttpPut]
        public IActionResult Edit(SecurityGuard secury)
        {
            var db = new ChopContext();
            db.SecurityGuards.Update(secury);
            db.SaveChanges();
            return Ok(secury);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var db = new ChopContext();
            var segu = db.SecurityGuards.SingleOrDefault(s => s.Id == id);
            if (segu == null)
                return NotFound();
            db.SecurityGuards.Remove(segu);
            db.SaveChanges();
            return Ok(segu);
        }
    }
}