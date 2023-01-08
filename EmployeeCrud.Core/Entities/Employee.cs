
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCrud.Core.Entities
{
    public class Employee 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public long Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int  Age { get; set; }
    }
}
