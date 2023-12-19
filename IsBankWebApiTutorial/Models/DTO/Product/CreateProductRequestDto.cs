using System.ComponentModel.DataAnnotations;

namespace IsBankWebApiTutorial.Models.DTO
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = "lorem ipsum..";
        public int UnitsInStock { get; set; } = 1;
        public decimal UnitPrice { get; set; }
    }
}
