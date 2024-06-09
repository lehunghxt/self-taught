using HXT.Domain.Base;
using HXT.Domain.Departments;
using HXT.Domain.Salaries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HXT.Domain.Users
{
    [Table("Users")]
    public partial class User : BaseEntity
    {
        public User()
        {
            Salaries = new HashSet<Salary>();
        }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Guid DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
