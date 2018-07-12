using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class AdminRepository : IAdminRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<Admin> GetAll()
        {
            return context.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return context.Admins.SingleOrDefault(d => d.Admin_Id == id);
        }
        public Admin Get(string Admin_Name)
        {
            return context.Admins.SingleOrDefault(d => d.Admin_Name == Admin_Name);
        }

        public int Insert(Admin admin)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.Admins.Count() + 1;
            li.Login_Name = admin.Admin_Name;
            li.Login_Password = admin.Admin_password;
            li.Login_type = "Admin";
            context.Logininfos.Add(li);

            context.Admins.Add(admin);
           
            return context.SaveChanges();
        }

        public int Update(Admin admin)
        {
            Admin adminToUpdate = context.Admins.SingleOrDefault(d => d.Admin_Id == admin.Admin_Id);
            adminToUpdate.Admin_Name = admin.Admin_Name;
            adminToUpdate.Admin_address = admin.Admin_address;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Admin adminToDelete = context.Admins.SingleOrDefault(d => d.Admin_Id == id);
            context.Admins.Remove(adminToDelete);
            return context.SaveChanges();
        }
    }
}
