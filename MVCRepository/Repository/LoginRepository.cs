using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MVCRepository
{
    public class LoginRepository
    {
        MVCDbContext context = new MVCDbContext();
        
        public string[] checkLogin(string username,string password)
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Logininfoes where Login_Name='" + username + "' And Login_Password='" + password + "'";
            string[] str = new string[2];

            try
            {
                SqlDataReader data = db.GetData(sql);
                if (data.Read())
                {
                    str[0] = data["Login_acc_no"].ToString();
                    str[1] = data["Login_type"].ToString();
                }
            }
            catch
            {
                
            }
            return str;
        }
        public Logininfo Get(string Login_Name)
        {
            return context.Logininfos.SingleOrDefault(d => d.Login_Name == Login_Name);
        }
        public int Update(Logininfo li)
        {
            Logininfo loToUpdate = context.Logininfos.SingleOrDefault(d => d.Login_Name == li.Login_Name);
            return context.SaveChanges();
        }

        public User bringUser(string id)
        {
            UserRepository repo = new UserRepository();
            User data = repo.Get(Convert.ToInt32(id));

            return data;
        }

        public Admin bringAdmin(string id)
        {
            AdminRepository repo = new AdminRepository();
            Admin data = repo.Get(Convert.ToInt32(id));

            return data;
        }
        public BranchManager bringManager(string id)
        {
            BranchManagerRepository repo = new BranchManagerRepository();
            BranchManager data = repo.Get(Convert.ToInt32(id));

            return data;
        }
        public Cashier bringCashier(string id)
        {
            CashierRepository repo = new CashierRepository();
            Cashier data = repo.Get(Convert.ToInt32(id));

            return data;
        }
        public HROfficer bringHROfficer(string id)
        {
            HROfficerRepository repo = new HROfficerRepository();
            HROfficer data = repo.Get(Convert.ToInt32(id));

            return data;
        }
        public LoanOfficer bringLOfficer(string id)
        {
            LORepository repo = new LORepository();
            LoanOfficer data = repo.Get(Convert.ToInt32(id));

            return data;
        }
        public MDirector bringMD(string id)
        {
            MDirectorRepository repo = new MDirectorRepository();
            MDirector data = repo.Get(Convert.ToInt32(id));

            return data;
        }
        public Officer bringOfficer(string id)
        {
            OfficerRepository repo = new OfficerRepository();
            Officer data = repo.Get(Convert.ToInt32(id));

            return data;
        }
        public TOfficer bringTOfficer(string id)
        {
            TOfficerRepository repo = new TOfficerRepository();
            TOfficer data = repo.Get(Convert.ToInt32(id));

            return data;
        }
    }
}
