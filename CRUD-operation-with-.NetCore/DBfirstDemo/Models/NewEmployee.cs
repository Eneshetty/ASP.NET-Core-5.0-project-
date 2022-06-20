using System;
using System.Collections.Generic;

#nullable disable

namespace DBfirstDemo.Models
{
    public partial class NewEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int? DeptId { get; set; }

        public virtual Dept Dept { get; set; }
    }
}
