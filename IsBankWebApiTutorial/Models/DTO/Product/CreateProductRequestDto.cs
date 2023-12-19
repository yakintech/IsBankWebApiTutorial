using System.ComponentModel.DataAnnotations;

namespace IsBankWebApiTutorial.Models.DTO
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
