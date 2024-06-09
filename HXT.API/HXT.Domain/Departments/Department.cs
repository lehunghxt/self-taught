using HXT.Domain.Base;
using HXT.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace HXT.Domain.Departments
{
    [Table("Departments")]
    public partial class Department : BaseEntity
    {
        public string DepartmentName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
