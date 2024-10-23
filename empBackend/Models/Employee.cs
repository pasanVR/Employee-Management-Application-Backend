using System.ComponentModel.DataAnnotations.Schema;

namespace empBackend.Models
{
    [Table("employees")]
    public class Employee
    {
        public long Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email_Id")]
        public string EmailId { get; set; }
    }
}
