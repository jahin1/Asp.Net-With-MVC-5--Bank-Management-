using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public class LORepository:ILORepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<LoanOfficer> GetAll()
        {
            return context.LoanOfficers.ToList();
        }

        public LoanOfficer Get(int id)
        {
            return context.LoanOfficers.SingleOrDefault(d => d.LOfficer_Id == id);
        }

        public int Insert(LoanOfficer LoanOfficer)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.LoanOfficers.Count()+1;
            li.Login_Name = LoanOfficer.LOfficer_name;
            li.Login_Password = LoanOfficer.LOfficer_Password;
            li.Login_type = "LOfficer";
            context.Logininfos.Add(li);

            context.LoanOfficers.Add(LoanOfficer);
            return context.SaveChanges();
        }

        public int Update(LoanOfficer LoanOfficer)
        {
            LoanOfficer loanofficerToUpdate = context.LoanOfficers.SingleOrDefault(d => d.LOfficer_Id == LoanOfficer.LOfficer_Id);
            loanofficerToUpdate.LOfficer_name = LoanOfficer.LOfficer_name;

            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            LoanOfficer loanofficerToDelete = context.LoanOfficers.SingleOrDefault(d => d.LOfficer_Id == id);
            context.LoanOfficers.Remove(loanofficerToDelete);
            return context.SaveChanges();
        }
    }
}
