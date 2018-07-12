using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class Officer
    {
        [Key]
        public int Officer_Id { get; set; }
        public string Officer_Name { get; set; }
        public string Officer_password { get; set; }
        public string Officer_address { get; set; }
        public string Officer_mobile { get; set; }
        public double Officer_Salary { get; set; }
        public string Officer_LastPaymentDate { get; set; }
        public double Officer_TotalPayment { get; set; }
        public double Officer_Balance { get; set; }
        public string Officer_branch { get; set; }
    }
}
