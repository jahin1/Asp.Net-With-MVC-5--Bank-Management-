using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class TOfficerRepository : ITOfficerRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<TOfficer> GetAll()
        {
            return context.TOfficers.ToList();
        }

        public TOfficer Get(int id)
        {
            return context.TOfficers.SingleOrDefault(d => d.TO_accId == id);
        }

        public int Insert(TOfficer TOfficer)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.TOfficers.Count()+1;
            li.Login_Name = TOfficer.TO_name;
            li.Login_Password = TOfficer.TO_password;
            li.Login_type = "TOfficer";
            context.Logininfos.Add(li);
            context.TOfficers.Add(TOfficer);
            return context.SaveChanges();
        }

        public int Update(TOfficer TOfficer)
        {
            TOfficer TOfficerToUpdate = context.TOfficers.SingleOrDefault(d => d.TO_accId == TOfficer.TO_accId);
            TOfficerToUpdate.TO_name = TOfficer.TO_name;
            TOfficerToUpdate.TO_password = TOfficer.TO_password;
            TOfficerToUpdate.TO_address = TOfficer.TO_address;
            TOfficerToUpdate.TO_mobile = TOfficer.TO_mobile;
            TOfficerToUpdate.TO_branch = TOfficer.TO_branch;
         

            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            TOfficer TOfficerToDelete = context.TOfficers.SingleOrDefault(d => d.TO_accId == id);
            context.TOfficers.Remove(TOfficerToDelete);
            return context.SaveChanges();
        }
    }
}
