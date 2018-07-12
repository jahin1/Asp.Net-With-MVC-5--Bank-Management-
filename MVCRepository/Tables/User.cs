using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public class User
    {
        [Key]
        public int User_acc_no { get; set; }
        public string User_Name { get; set; }
        public string User_password { get; set; }
        public string User_address { get; set; }
        public string User_mobile { get; set; }
        public double User_balance{ get; set; }
        public string User_acc_type { get; set; }
        public string Deadline { get; set; }

    }
}
