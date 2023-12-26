using IsBankWebApiTutorial.Models.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsBankWebApiTutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        IsBankDbContext db;
        public OrderController()
        {
            db = new IsBankDbContext();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = db.Orders.Include(q => q.Customer).Where(q => !q.IsDeleted)
                  .Select(x => new
                  {
                      x.Id,
                      x.Note,
                      x.AddDate,
                      x.Customer,
                      x.OrderNumber
                  })
                .ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var order = db.Orders.Include(q => q.Customer).FirstOrDefault(q => !q.IsDeleted && q.Id == id);

            if(order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);

            }

        }


        [HttpPost]
        public IActionResult Create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = db.Orders.FirstOrDefault(q => q.Id == id);
 
            if(order != null)
            {
                order.IsDeleted = true;
                db.SaveChanges();
                return Ok(order);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
