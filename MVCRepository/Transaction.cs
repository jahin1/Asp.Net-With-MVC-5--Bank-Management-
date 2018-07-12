using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class Transaction
    {
        [Key]
        public int Tr_Id { get; set; }
        public string Tr_Through { get; set; }
        public string Tr_EmpType { get; set; }
        public string Tr_AccName { get; set; }
        public string Tr_Type { get; set; }
        public double Tr_Amount { get; set; }
        public string Tr_Date { get; set; }
    }
}
