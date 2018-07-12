using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public  class OfficerRepository : IOfficerRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<Officer> GetAll()
        {
            return context.Officers.ToList();
        }

        public Officer Get(int Officer_Id)
        {
            return context.Officers.SingleOrDefault(d => d.Officer_Id == Officer_Id);
        }

        public int Insert(Officer officer)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.Officers.Count()+1;
            li.Login_Name = officer.Officer_Name;
            li.Login_Password = officer.Officer_password;
            li.Login_type = "Officer";
            context.Logininfos.Add(li);

            context.Officers.Add(officer);
            return context.SaveChanges();
        }

        public int Update(Officer officer)
        {
            Officer officerToUpdate = context.Officers.SingleOrDefault(d => d.Officer_Id == officer.Officer_Id);
            officerToUpdate.Officer_Name = officer.Officer_Name;
            officerToUpdate.Officer_address = officer.Officer_address;
            return context.SaveChanges();
        }

        public int Delete(int Officer_Id)
        {
            Officer officerToDelete = context.Officers.SingleOrDefault(d => d.Officer_Id == Officer_Id);
            context.Officers.Remove(officerToDelete);
            return context.SaveChanges();
        }
    }
}
