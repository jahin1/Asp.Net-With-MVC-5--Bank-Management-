using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public interface ILoanRepository
    {
        List<LInfo> GetAll();
        LInfo Get(int id);
        int Insert(LInfo loan,User user);
        int Update(LInfo loan,User user);
        
    }
}
