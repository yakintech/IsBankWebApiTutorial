namespace IsBankWebApiTutorial.Models.DTO
{
    public class GetAllProductsResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime AddDate { get; set; }

        public GetCategoryDto Category { get; set; }
        public GetSupplierDto Supplier { get; set; }
    }

    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetSupplierDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
    }
}
