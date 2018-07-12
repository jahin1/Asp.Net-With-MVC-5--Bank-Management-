using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public class Logininfo
    {
        [Key]
        public int id { get; set; }
        public int Login_acc_no { get; set; }
        public string Login_Name { get; set; }
        public string Login_Password { get; set; }
        public string Login_type { get; set; }

    }
}
