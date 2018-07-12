using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class Cashier
    {
        [Key]
        public int Cashier_Id { get; set; }
        public string Cashier_Name { get; set; }
        public string Cashier_password { get; set; }
        public string Cashier_address { get; set; }
        public string Cashier_mobile { get; set; }
        public double Cashier_Salary { get; set; }
        public string Cashier_LastPaymentDate { get; set; }
        public double Cashier_TotalPayment { get; set; }
        public double Cashier_Balance { get; set; }
        public string Cashier_branch{ get; set; }
    }
}
