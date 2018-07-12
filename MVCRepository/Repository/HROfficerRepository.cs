using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class HROfficerRepository : IHROfficerRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<HROfficer> GetAll()
        {
            return context.HROfficers.ToList();
        }

        public HROfficer Get(int id)
        {
            return context.HROfficers.SingleOrDefault(d => d.HR_acc_Id == id);
        }

        public int Insert(HROfficer HROfficer)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.HROfficers.Count()+1;
            li.Login_Name = HROfficer.HR_name;
            li.Login_Password = HROfficer.HR_password;
            li.Login_type = "HROfficer";

            context.Logininfos.Add(li);
            context.HROfficers.Add(HROfficer);
            return context.SaveChanges();
        }

        public int Update(HROfficer HROfficer)
        {
            HROfficer HROfficerToUpdate = context.HROfficers.SingleOrDefault(d => d.HR_acc_Id == HROfficer.HR_acc_Id);
            HROfficerToUpdate.HR_name = HROfficer.HR_name;
            HROfficerToUpdate.HR_password = HROfficer.HR_password;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            HROfficer HROfficerToDelete = context.HROfficers.SingleOrDefault(d => d.HR_acc_Id == id);
            context.HROfficers.Remove(HROfficerToDelete);
            return context.SaveChanges();
        }
    }
}
