using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCRepository
{
    public class MDirector
    {
        [Key]
        public int MD_Id  { get; set; }
        public string MD_name { get; set; }
        public string MD_password { get; set; }
        public string MD_address { get; set; }
        public double MD_Salary { get; set; }
        public double MD_Balance { get; set; }
        public string MD_mobile { get; set; }
    }
}
