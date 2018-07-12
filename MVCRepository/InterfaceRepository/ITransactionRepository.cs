using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAll();
        List<Transaction> GetByType(string Tr_Type);
        List<Transaction> GetByEmp(string Tr_Through);
        List<Transaction> GetByPos(string Tr_EmpType);
        List<Transaction> GetToday();
        List<Transaction> GetYesterday();
        List<Transaction> Get6Months();
        List<Transaction> GetCurrentYear();
        List<Transaction> GetToday(string Manager_branch);
        List<Transaction> GetYesterday(string Manager_branch);
        List<Transaction> Get6Months(string Manager_branch);
        List<Transaction> GetCurrentYear(string Manager_branch);
        int Insert(Transaction Tr);

    }
}
