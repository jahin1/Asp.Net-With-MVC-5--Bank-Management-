using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MVCRepository
{
    public class TransactionRepository: ITransactionRepository
    {
        MVCDbContext context = new MVCDbContext();
        public List<Transaction> GetAll()
        {
            return context.Transactions.ToList();
        }
        public int Insert(Transaction Tr)
        {
            context.Transactions.Add(Tr);
            return context.SaveChanges();
        }

        public List<Transaction> GetByType(string Tr_Type)
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Type='"+ Tr_Type+"'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> GetByEmp(string Tr_Through)
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Through='" + Tr_Through + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }
        public List<Transaction> GetByPos(string Tr_EmpType)
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_EmpType='" + Tr_EmpType + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }
        public List<Transaction> GetToday()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Date ='" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> GetToday(string Manager_branch)
        {
            

            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Date ='" + DateTime.Today.ToString("yyyy-MM-dd")+"' AND Tr_Branch='" + Manager_branch+"'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }
        public List<Transaction> GetYesterday()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Date = '" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") +"'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType= data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> GetYesterday(string Manager_branch)
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Date = '" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + "' and Tr_Branch='" + Manager_branch + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> Get6Months()
        {
            DataAccess db = new DataAccess();

            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 06, 30);


            string sql = "SELECT* from Transactions where Tr_Date BETWEEN '" + firstDay.ToString("yyyy-MM-dd") + "' AND '" + lastDay.ToString("yyyy-MM-dd") + "'";

            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> Get6Months(string Manager_branch)
        {
            DataAccess db = new DataAccess();

            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 06, 30);


            string sql = "SELECT* from Transactions where (Tr_Date BETWEEN '" + firstDay.ToString("yyyy-MM-dd") + "'AND '" + lastDay.ToString("yyyy-MM-dd") + "' ) AND Tr_Branch='" + Manager_branch + "'";

            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> GetCurrentYear()
        {
            DataAccess db = new DataAccess();

            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);

            string sql = "SELECT* from Transactions where Tr_Date BETWEEN '" + firstDay.ToString("yyyy-MM-dd") + "'AND '" + lastDay.ToString("yyyy-MM-dd") + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> GetCurrentYear(string Manager_branch)
        {
            DataAccess db = new DataAccess();

            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);


            string sql = "SELECT* from Transactions where (Tr_Date BETWEEN '" + firstDay.ToString("yyyy-MM-dd") + "'AND '" + lastDay.ToString("yyyy-MM-dd") + "' ) AND Tr_Branch='" + Manager_branch + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_AccName"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();
                l.Tr_Branch = data["Tr_Branch"].ToString();

                ll.Add(l);
            }

            return ll;
        }

    }
}
