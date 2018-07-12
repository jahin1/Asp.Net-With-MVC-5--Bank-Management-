using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCRepository
{
    public class HROfficer
    {
        [Key]
        public int HR_acc_Id { get; set; }
        public string HR_name { get; set; }
        public string HR_password { get; set; }
        public string HR_address { get; set; }
        public string HR_mobile { get; set; }
        public double HR_Salary { get; set; }
        public string HR_LastPaymentDate { get; set; }
        public double HR_TotalPayment { get; set; }
        public double HR_Balance { get; set; }
        public string HR_branch { get; set; }

    }
}
