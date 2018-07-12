using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class MDirectorRepository : IMDirectorRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<MDirector> GetAll()
        {
            return context.MDirectors.ToList();
        }

        public MDirector Get(int id)
        {
            return context.MDirectors.SingleOrDefault(d => d.MD_Id == id);
        }

        public int Insert(MDirector MDirector)
        {
            Logininfo li = new Logininfo();
            li.Login_acc_no = context.MDirectors.Count()+1;
            li.Login_Name = MDirector.MD_name;
            li.Login_Password = MDirector.MD_password;
            li.Login_type = "MD";
            context.Logininfos.Add(li);

            context.MDirectors.Add(MDirector);
            return context.SaveChanges();
        }

        public int Update(MDirector MDirector)
        {
            MDirector MDirectorToUpdate = context.MDirectors.SingleOrDefault(d => d.MD_Id == MDirector.MD_Id);
            MDirectorToUpdate.MD_name = MDirector.MD_name;
            MDirectorToUpdate.MD_password = MDirector.MD_password;
            MDirectorToUpdate.MD_address = MDirector.MD_address;
            MDirectorToUpdate.MD_mobile = MDirector.MD_mobile;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            MDirector MDirectorToDelete = context.MDirectors.SingleOrDefault(d => d.MD_Id == id);
            context.MDirectors.Remove(MDirectorToDelete);
            return context.SaveChanges();
        }


    }
}
