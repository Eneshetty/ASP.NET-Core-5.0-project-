using System;
using System.Collections.Generic;

#nullable disable

namespace DBfirstDemo.Models
{
    public partial class Dept
    {
        public Dept()
        {
            NewEmployees = new HashSet<NewEmployee>();
        }

        public int DeptId { get; set; }
        public string Dname { get; set; }

        public virtual ICollection<NewEmployee> NewEmployees { get; set; }
    }
}
