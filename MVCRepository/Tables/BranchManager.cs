using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class BranchManager
    {
        [Key]
        public int Manager_Id { get; set; }
        public string Manager_Name { get; set; }
        public string Manager_password { get; set; }
        public string Manager_address { get; set; }
        public string Manager_mobile { get; set; }
        public double Manager_Salary { get; set; }
        public double Manager_Balance { get; set; }
        public string Manager_LastPaymentDate { get; set; }
        public double Manager_TotalPayment { get; set; }
        public string Manager_branch { get; set; }

    }
}
