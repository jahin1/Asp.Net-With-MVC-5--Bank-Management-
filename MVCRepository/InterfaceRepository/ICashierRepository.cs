using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public interface ICashierRepository
    {
        List<Cashier> GetAll();
        Cashier Get(int Cashier_Id);
        int Insert(Cashier cashier);
        int Update(Cashier cashier);
        int Delete(int Cashier_Id);
    }
}
