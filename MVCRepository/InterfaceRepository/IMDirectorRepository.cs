using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public interface IMDirectorRepository
    {
        List<MDirector> GetAll();
        MDirector Get(int MD_Id);
        int Insert(MDirector MDirector);
        int Update(MDirector MDirector);
        int Delete(int MD_Id);

    }
}
