using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
   public interface IBranchManagerRepository
    {
        List<BranchManager> GetAll();
        BranchManager Get(int Manager_Id);
        int Insert(BranchManager branchMangaer);
        int Update(BranchManager branchMangaer);
        int Delete(int Manager_Id);
    }
}
