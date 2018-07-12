using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public  class UserRepository : IUserRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Get(int id)
        {
            return context.Users.SingleOrDefault(d => d.User_acc_no == id);
        }
  
        public User Get(string username)
        {
            return context.Users.SingleOrDefault(d => d.User_Name == username);
        }

        public int Insert(User User)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.Users.Count()+1;
            li.Login_Name = User.User_Name;
            li.Login_Password = User.User_password;
            li.Login_type = "User";
            context.Logininfos.Add(li);

            context.Users.Add(User);
            return context.SaveChanges();
        }

        public int Update(User User)
        {
            User userToUpdate = context.Users.SingleOrDefault(d => d.User_acc_no == User.User_acc_no);
            userToUpdate.User_Name = User.User_Name;
            userToUpdate.User_address = User.User_address;
            return context.SaveChanges();
        }
        public void Get(object v)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            User userToDelete = context.Users.SingleOrDefault(d => d.User_acc_no == id);
            context.Users.Remove(userToDelete);
            return context.SaveChanges();
        }
    }
}
