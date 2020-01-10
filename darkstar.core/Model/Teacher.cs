using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkstar.core.Model
{
    public class Teacher : Person
    {

        [Key]
        public int TeacherID { get; set; }
        public int? Meeting { get; set; }
        public string TeacherIDNo { get; set; }
    }
}
