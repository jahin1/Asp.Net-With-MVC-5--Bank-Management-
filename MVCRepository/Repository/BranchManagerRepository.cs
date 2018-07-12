using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public  class BranchManagerRepository : IBranchManagerRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<BranchManager> GetAll()
        {
            return context.BranchManagers.ToList();
        }

        public BranchManager Get(int Manager_Id)
        {
            return context.BranchManagers.SingleOrDefault(d => d.Manager_Id == Manager_Id);
        }

        public int Insert(BranchManager branchMangaer)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.BranchManagers.Count()+1;
            li.Login_Name = branchMangaer.Manager_Name;
            li.Login_Password = branchMangaer.Manager_password;
            li.Login_type = "Manager";
            context.Logininfos.Add(li);
            context.BranchManagers.Count();

            context.BranchManagers.Add(branchMangaer);
            return context.SaveChanges();
        }

        public int Update(BranchManager branchMangaer)
        {
            BranchManager branchMangaerToUpdate = context.BranchManagers.SingleOrDefault(d => d.Manager_Id == branchMangaer.Manager_Id);
            branchMangaerToUpdate.Manager_Name = branchMangaer.Manager_Name;
            branchMangaerToUpdate.Manager_address = branchMangaer.Manager_address;
            return context.SaveChanges();
        }

        public int Delete(int Manager_Id)
        {
            BranchManager branchMangaerToDelete = context.BranchManagers.SingleOrDefault(d => d.Manager_Id == Manager_Id);
            context.BranchManagers.Remove(branchMangaerToDelete);
            return context.SaveChanges();
        }
    }
}
