using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public interface IHROfficerRepository
    {
        List<HROfficer> GetAll();
        HROfficer Get(int HR_acc_Id);
        int Insert(HROfficer HROfficer);
        int Update(HROfficer HROfficer);
        int Delete(int HR_acc_Id);
    }
}
