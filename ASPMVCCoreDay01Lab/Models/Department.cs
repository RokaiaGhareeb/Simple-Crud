using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMVCCoreDay01Lab.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public String DeptName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
