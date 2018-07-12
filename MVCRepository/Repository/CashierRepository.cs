using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public  class CashierRepository : ICashierRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<Cashier> GetAll()
        {
            return context.Cashiers.ToList();
        }

        public Cashier Get(int Cashier_Id)
        {
            return context.Cashiers.SingleOrDefault(d => d.Cashier_Id == Cashier_Id);
        }

        public int Insert(Cashier cashier)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.Cashiers.Count()+1;
            li.Login_Name = cashier.Cashier_Name;
            li.Login_Password = cashier.Cashier_password;
            li.Login_type = "Cashier";
            context.Logininfos.Add(li);

            context.Cashiers.Add(cashier);
            return context.SaveChanges();
        }

        public int Update(Cashier cashier)
        {
            Cashier cashierToUpdate = context.Cashiers.SingleOrDefault(d => d.Cashier_Id == cashier.Cashier_Id);
            cashierToUpdate.Cashier_Name = cashier.Cashier_Name;
            cashierToUpdate.Cashier_address = cashier.Cashier_address;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Cashier cashierToDelete = context.Cashiers.SingleOrDefault(d => d.Cashier_Id == id);
            context.Cashiers.Remove(cashierToDelete);
            return context.SaveChanges();
        }
    }
}
