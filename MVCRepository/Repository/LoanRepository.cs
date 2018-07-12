using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MVCRepository
{
    public class LoanRepository : ILoanRepository
    {
        MVCDbContext context = new MVCDbContext();
        public List<LInfo> GetAll()
        {
            return context.Linfos.ToList();
        }

        public LInfo Get(int id)
        {
            return context.Linfos.SingleOrDefault(d => d.Loan_Id == id);
        }

        public LInfo GetUser(int User_acc_no)
        {
            return context.Linfos.SingleOrDefault(d => d.User_acc_no == User_acc_no);
        }

        public int Insert(LInfo loan,User user)
        {
            UserRepository urepo = new UserRepository();
            urepo.Insert(user);
          
            loan.User_acc_no = user.User_acc_no;
            context.Linfos.Add(loan);


            return context.SaveChanges();
        }

        public int Update(LInfo loan, User User)
        {
            LInfo loantoUpdate = context.Linfos.SingleOrDefault(d => d.Loan_Id == loan.Loan_Id);
            User userToUpdate = context.Users.SingleOrDefault(d => d.User_acc_no == User.User_acc_no);

            loantoUpdate.User_acc_no = User.User_acc_no;
            userToUpdate.User_Name = User.User_Name;
            userToUpdate.User_address = User.User_address;
            return context.SaveChanges();
        }

        public List<LInfo> GetAllUnapproved()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from LInfoes where Status='Unapproved'";
            List<LInfo> ll = new List<LInfo>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                LInfo l = new LInfo();
                l.Interest_Rate = Convert.ToInt32(data["Interest_Rate"]);
                l.LoanCause = data["LoanCause"].ToString();
                l.Loan_Amount = Convert.ToInt32(data["Loan_Amount"]);
                l.Loan_Amount_Paid = Convert.ToInt32(data["Loan_Amount_Paid"]);
                l.AmountTo_Pay = Convert.ToInt32(data["AmountTo_Pay"]);
                l.Loan_Date = data["Loan_Date"].ToString();
                l.Loan_Deadline = data["Loan_Deadline"].ToString();
                l.Loan_Id= Convert.ToInt32(data["Loan_Id"]);
                l.LOfficer_Id = Convert.ToInt32(data["LOfficer_Id"]);
                l.Manager_Approval = data["Manager_Approval"].ToString();
                l.MD_Approval = data["MD_Approval"].ToString();
                l.Status = data["Status"].ToString();
                l.User_acc_no = Convert.ToInt32(data["User_acc_no"]);
                l.Loan_Branch = data["Loan_Branch"].ToString();

                ll.Add(l);

            }

            return ll ;
        }
        public List<LInfo> GetAllNoapprovalfromManager(string Manager_Branch)
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from LInfoes where Manager_Approval='No' AND Loan_Branch='"+ Manager_Branch+"'";
            List<LInfo> ll = new List<LInfo>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                LInfo l = new LInfo();
                l.Interest_Rate = Convert.ToInt32(data["Interest_Rate"]);
                l.LoanCause = data["LoanCause"].ToString();
                l.Loan_Amount = Convert.ToInt32(data["Loan_Amount"]);
                l.Loan_Amount_Paid = Convert.ToInt32(data["Loan_Amount_Paid"]);
                l.AmountTo_Pay = Convert.ToInt32(data["AmountTo_Pay"]);
                l.Loan_Date = data["Loan_Date"].ToString();
                l.Loan_Deadline = data["Loan_Deadline"].ToString();
                l.Loan_Id = Convert.ToInt32(data["Loan_Id"]);
                l.LOfficer_Id = Convert.ToInt32(data["LOfficer_Id"]);
                l.Manager_Approval = data["Manager_Approval"].ToString();
                l.MD_Approval = data["MD_Approval"].ToString();
                l.Status = data["Status"].ToString();
                l.User_acc_no = Convert.ToInt32(data["User_acc_no"]);
                l.Loan_Branch = data["Loan_Branch"].ToString();

                ll.Add(l);

            }

            return ll;
        }

        public List<LInfo> GetAllActive()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from LInfoes where Status='Active'";
            List<LInfo> ll = new List<LInfo>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                LInfo l = new LInfo();
                l.Interest_Rate = Convert.ToInt32(data["Interest_Rate"]);
                l.LoanCause = data["LoanCause"].ToString();
                l.Loan_Amount = Convert.ToInt32(data["Loan_Amount"]);
                l.Loan_Amount_Paid = Convert.ToInt32(data["Loan_Amount_Paid"]);
                l.AmountTo_Pay = Convert.ToInt32(data["AmountTo_Pay"]);
                l.Loan_Date = data["Loan_Date"].ToString();
                l.Loan_Deadline = data["Loan_Deadline"].ToString();
                l.Loan_Id = Convert.ToInt32(data["Loan_Id"]);
                l.LOfficer_Id = Convert.ToInt32(data["LOfficer_Id"]);
                l.Manager_Approval = data["Manager_Approval"].ToString();
                l.MD_Approval = data["MD_Approval"].ToString();
                l.Status = data["Status"].ToString();
                l.User_acc_no = Convert.ToInt32(data["User_acc_no"]);
                l.Loan_Branch = data["Loan_Branch"].ToString();

                ll.Add(l);

            }

            return ll;
        }

        public List<LInfo> GetAllInActive()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from LInfoes where Status='InActive'";
            List<LInfo> ll = new List<LInfo>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                LInfo l = new LInfo();
                l.Interest_Rate = Convert.ToInt32(data["Interest_Rate"]);
                l.LoanCause = data["LoanCause"].ToString();
                l.Loan_Amount = Convert.ToInt32(data["Loan_Amount"]);
                l.Loan_Amount_Paid = Convert.ToInt32(data["Loan_Amount_Paid"]);
                l.AmountTo_Pay = Convert.ToInt32(data["AmountTo_Pay"]);
                l.Loan_Date = data["Loan_Date"].ToString();
                l.Loan_Deadline = data["Loan_Deadline"].ToString();
                l.Loan_Id = Convert.ToInt32(data["Loan_Id"]);
                l.LOfficer_Id = Convert.ToInt32(data["LOfficer_Id"]);
                l.Manager_Approval = data["Manager_Approval"].ToString();
                l.MD_Approval = data["MD_Approval"].ToString();
                l.Status = data["Status"].ToString();
                l.User_acc_no = Convert.ToInt32(data["User_acc_no"]);
                l.Loan_Branch = data["Loan_Branch"].ToString();

                ll.Add(l);

            }

            return ll;
        }
        public int Manager_Approval_Update(LInfo loan)
        {
            LInfo loantoUpdate = context.Linfos.SingleOrDefault(d => d.Loan_Id == loan.Loan_Id);
            loantoUpdate.Status = loan.Status;

            return context.SaveChanges();
        }

        public List<LInfo> GetAllNoapprovalfromMD()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from LInfoes where Manager_Approval='Yes' AND MD_Approval='No'";
            List<LInfo> ll = new List<LInfo>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                LInfo l = new LInfo();
                l.Interest_Rate = Convert.ToInt32(data["Interest_Rate"]);
                l.LoanCause = data["LoanCause"].ToString();
                l.Loan_Amount = Convert.ToInt32(data["Loan_Amount"]);
                l.Loan_Amount_Paid = Convert.ToInt32(data["Loan_Amount_Paid"]);
                l.AmountTo_Pay = Convert.ToInt32(data["AmountTo_Pay"]);
                l.Loan_Date = data["Loan_Date"].ToString();
                l.Loan_Deadline = data["Loan_Deadline"].ToString();
                l.Loan_Id = Convert.ToInt32(data["Loan_Id"]);
                l.LOfficer_Id = Convert.ToInt32(data["LOfficer_Id"]);
                l.Manager_Approval = data["Manager_Approval"].ToString();
                l.MD_Approval = data["MD_Approval"].ToString();
                l.Status = data["Status"].ToString();
                l.User_acc_no = Convert.ToInt32(data["User_acc_no"]);
                l.Loan_Branch = data["Loan_Branch"].ToString();

                ll.Add(l);

            }
            return ll;
        }

        public int MD_Approval_Update(LInfo loan)
        {
            LInfo loantoUpdate = context.Linfos.SingleOrDefault(d => d.Loan_Id == loan.Loan_Id);
            loantoUpdate.Status = loan.Status;

            return context.SaveChanges();
        }

    }
}
