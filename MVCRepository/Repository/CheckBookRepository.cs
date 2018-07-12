using MVCRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRepository
{
    public class CheckBookRepository:ICheckBookRepository
    {
        MVCDbContext context = new MVCDbContext();

        public List<CheckBook> GetAll()
        {
            return context.CheckBooks.ToList();
        }
        public int Insert(CheckBook checkBook)
        {
            CheckBook li = new CheckBook();
            li.Check_User_name = checkBook.Check_User_name;
            li.Check_apply_Date = checkBook.Check_apply_Date;
            li.Check_status = checkBook.Check_status;
            li.Check_fixed_Date = checkBook.Check_fixed_Date;
         

            context.CheckBooks.Add(checkBook);

            return context.SaveChanges();
        }

        public int Update(CheckBook CheckBook)
        {
            CheckBook CheckBookToUpdate = context.CheckBooks.SingleOrDefault(d => d.Check_User_name == CheckBook.Check_User_name);
            CheckBookToUpdate.Check_status = CheckBook.Check_status;
            CheckBookToUpdate.Check_fixed_Date = CheckBook.Check_fixed_Date;
            return context.SaveChanges();
        }


    }
}
