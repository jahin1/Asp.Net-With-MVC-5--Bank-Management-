using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public interface IOfficerRepository
    {
        List<Officer> GetAll();
        Officer Get(int Officer_Id);
        int Insert(Officer officer);
        int Update(Officer officer);
        int Delete(int Officer_Id);
    }
}
