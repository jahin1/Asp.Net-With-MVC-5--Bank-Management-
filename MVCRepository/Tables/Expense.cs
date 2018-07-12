using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCRepository
{
    public class Expense
    {
        [Key]
        public int Expense_Id { get; set; }
        public string Expense_name{ get; set; }
        public string Expense_date { get; set; }
        public string Expense_amount { get; set; }
    }
}
