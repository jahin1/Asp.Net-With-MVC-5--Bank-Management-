using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public interface ILORepository
    {
       List<LoanOfficer> GetAll();
       LoanOfficer Get(int LOfficer_Id);
       int Insert(LoanOfficer LoanOfficer);
       int Update(LoanOfficer LoanOfficer);
       int Delete(int LOfficer_Id);
    }
}
