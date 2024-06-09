using HXT.Domain.Base;
using HXT.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace HXT.Domain.Salaries
{
    [Table("Salaries")]
    public partial class Salary : BaseEntity
    {
        public Salary()
        {

        }
        public Guid UserId { get; set; }
        public float CoefficientsSalary { get; set; }
        public float WorkDays { get; set; }
        public decimal TotalSalary { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
