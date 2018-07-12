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
                l.Tr_AccName = data["Tr_From"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();

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
                l.Tr_AccName = data["Tr_From"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();

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
                l.Tr_AccName = data["Tr_From"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();

                ll.Add(l);
            }

            return ll;
        }
        public List<Transaction> GetToday()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Date='" + DateTime.Today.ToString() + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_From"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();

                ll.Add(l);
            }

            return ll;
        }
        public List<Transaction> GetYesterday()
        {
            DataAccess db = new DataAccess();
            string sql = "Select * from Transactions where Tr_Date='" + DateTime.Today.AddDays(-1).ToString() + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_From"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType= data["Tr_EmpType"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        public List<Transaction> Get6Months()
        {
            DataAccess db = new DataAccess();
            

           string sql = "SELECT* from Transactions where Tr_Date BETWEEN '"+DateTime.Today.ToString()+"'AND '"+ DateTime.Today.AddMonths(-6).ToString() + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_AccName = data["Tr_From"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();

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


            string sql = "SELECT* from Transactions where Tr_Date BETWEEN '" + firstDay.ToString() + "'AND '" + lastDay.ToString() + "'";
            List<Transaction> ll = new List<Transaction>();

            SqlDataReader data = db.GetData(sql);

            while (data.Read())
            {
                Transaction l = new Transaction();
                l.Tr_Id = Convert.ToInt32(data["Tr_Id"]);
                l.Tr_Through = data["Tr_Through"].ToString();
                l.Tr_User = data["Tr_From"].ToString();
                l.Tr_Type = data["Tr_Type"].ToString();
                l.Tr_Amount = Convert.ToInt32(data["Tr_Amount"]);
                l.Tr_Date = data["Tr_Date"].ToString();
                l.Tr_EmpType = data["Tr_EmpType"].ToString();

                ll.Add(l);
            }

            return ll;
        }

        

    }
}
