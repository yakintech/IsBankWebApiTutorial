using IsBankWebApiTutorial.Models.ORM;
using Microsoft.AspNetCore.Mvc;

namespace IsBankWebApiTutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        IsBankDbContext db;

        public CustomerController()
        {
            db = new IsBankDbContext();
        }

        //bu endpoint tum musterileri verir
        [HttpGet]
        public IActionResult Get()
        {
            var customers = db.Customers.Where(q => !q.IsDeleted).ToList();
            return Ok(customers);
        }

        //get customer by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = db.Customers.FirstOrDefault(q => q.Id == id && !q.IsDeleted);

            if(customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            
            Customer customer = db.Customers.FirstOrDefault(q => q.Id == id);

            if(customer != null)
            {
                customer.IsDeleted = true;
                db.SaveChanges();
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
       
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            var customerCheck = db.Customers.Any(q => !q.IsDeleted && q.Id == customer.Id);

            if (customerCheck)
            {
                db.Customers.Update(customer);
                db.SaveChanges();
                return Ok(customer);
            }
            else
            {
                var newCustomer = new Customer();
                newCustomer.Name = customer.Name;
                newCustomer.Surname = customer.Surname;
                newCustomer.BirthDate = customer.BirthDate;
                newCustomer.EMail = customer.EMail;

                db.Customers.Add(newCustomer);
                db.SaveChanges();

                return Ok(newCustomer);
            }
        }


        [HttpPatch]
        public IActionResult Patch(Customer customer)
        {
            var customerCheck = db.Customers.Any(q => !q.IsDeleted && q.Id == customer.Id);

            if (customerCheck)
            {
                db.Customers.Update(customer);
                db.SaveChanges();
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
