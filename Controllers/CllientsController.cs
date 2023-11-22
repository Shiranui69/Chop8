using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Chop.Models;

namespace Chop.Controllers
{
    [ ApiController]
    [Route("/clients")]
    public class ClientsController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var db = new ChopContext();
            return Ok(db.Clients);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var db = new ChopContext();
            var clo = db.Clients.SingleOrDefault(s => s.Id == id);
            if (clo == null)
                return NotFound();
            return Ok(clo);
        }
        [HttpPost]
        public IActionResult Add(Client client)
        {
            var db = new ChopContext();
            db.Clients.Add(client);
            db.SaveChanges();
            return Ok(client);
        }
        [HttpPut]
        public IActionResult Edit(Client clis)
        {
            var db = new ChopContext();
            db.Clients.Update(clis);
            db.SaveChanges();
            return Ok(clis);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new ChopContext();
            var client = db.Clients.SingleOrDefault(s => s.Id == id);
            if (client == null)
                return NotFound();
            db.Clients.Remove(client);
            db.SaveChanges();
            return Ok(client);
        }
    }
}
