using System.ComponentModel.DataAnnotations;

namespace IsBankWebApiTutorial.Models.ORM
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        [MaxLength(70)]
        public string EMail { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

    }
}
