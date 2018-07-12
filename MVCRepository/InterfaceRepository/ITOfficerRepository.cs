using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public interface ITOfficerRepository
    {
        List<TOfficer> GetAll();
        TOfficer Get(int TO_accId);
        int Insert(TOfficer TOfficer);
        int Update(TOfficer TOfficer);
        int Delete(int TO_accId);
    }
}
