using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public interface IAdminRepository
    {
        List<Admin> GetAll();
        Admin Get(int id);
        Admin Get(string Admin_Name);
        int Insert(Admin admin);
        int Update(Admin admin);
        int Delete(int id);
    }
}
