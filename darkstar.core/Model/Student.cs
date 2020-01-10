using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkstar.core.Model
{
    public class Student : Person
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentIDNo { get; set; }
    }
}
