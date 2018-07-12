using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCRepository
{
    public class TOfficer
    {
        [Key]
        public int TO_accId { get; set; }
        public string TO_name { get; set; }
        public string TO_password { get; set; }
        public string TO_address { get; set; }
        public string TO_mobile { get; set; }
        public string TO_Salary { get; set; }
        public string TO_LastPaymentDate { get; set; }
        public double TO_TotalPayment { get; set; }
        public string TO_Balance { get; set; }
        public string TO_branch{ get; set; }

    }
}
