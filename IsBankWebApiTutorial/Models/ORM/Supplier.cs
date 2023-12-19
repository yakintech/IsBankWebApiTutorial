namespace IsBankWebApiTutorial.Models.ORM
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }

        public string ContactTitle { get; set; } = string.Empty;

        public string ContactName { get; set; } = string.Empty;
    }
}
