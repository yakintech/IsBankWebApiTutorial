using System.ComponentModel.DataAnnotations.Schema;

namespace IsBankWebApiTutorial.Models.ORM
{
    public class Order : BaseEntity
    {
        public string Note { get; set; } = string.Empty;
        public int OrderNumber { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
