using HXT.Domain.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXT.Infrastructure.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public Department AddDepartment(string departmentName)
        {
            var department = new Department(departmentName);
            if (department.ValidOnAdd())
            {
                this.Add(department);
                return department;
            }
            else
                throw new Exception("Department invalid");
        }
    }
}
