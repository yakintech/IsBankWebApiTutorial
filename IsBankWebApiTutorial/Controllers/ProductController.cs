using IsBankWebApiTutorial.Models.DTO;
using IsBankWebApiTutorial.Models.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsBankWebApiTutorial.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        IsBankDbContext db;

        public ProductController()
        {
            db = new IsBankDbContext();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GetAllProductsResponseDto> response = db.Products.Where(q => !q.IsDeleted)
                .Select(x => new GetAllProductsResponseDto()
                {
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    Description = x.Description,
                    Id = x.Id,
                    AddDate = x.AddDate,
                    Category = new GetCategoryDto()
                    {
                        Name = x.Category.Name,
                        Id = x.Category.Id,
                    },
                    Supplier = new GetSupplierDto()
                    {
                        CompanyName = x.Supplier.CompanyName,
                        ContactName = x.Supplier.ContactName,
                        Id = x.Supplier.Id
                    }
                    
                    
                }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = db.Products.FirstOrDefault(q => !q.IsDeleted && q.Id == id);

           if(product == null)
            {
                return NotFound("Id: " + id + " not found!");
            }
            else
            {
                var response = new GetProductByIdResponseDto();
                response.Id = id;
                response.AddDate = product.AddDate;
                response.Name = product.Name;
                response.Description = product.Description;
                response.UnitPrice = product.UnitPrice;

                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequestDto model)
        {
          
                Product product = new Product();
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;

                db.Products.Add(product);
                db.SaveChanges();

                var response = new CreateProductResponseDto();
                response.Id = product.Id;
                response.Name = product.Name;
                response.Description = product.Description;
                response.UnitPrice = product.UnitPrice;
                response.TaxPrice = model.UnitPrice * 1.2M;
                response.AddDate = product.AddDate;


                return StatusCode(201, response);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if(product != null)
            {
                product.IsDeleted = true;
                db.SaveChanges();
                return Ok("");
            }
            else
            {
                return NotFound("Id: " + id + " not found!");
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateProductRequestDto model)
        {
            var product = db.Products.FirstOrDefault(q => !q.IsDeleted && q.Id == model.Id);

            if(product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;

                db.SaveChanges();

                return Ok("");

            }
            else
            {
                return NotFound();
            }
        }
    }
}
