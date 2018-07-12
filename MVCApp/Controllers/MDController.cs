using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRepository;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MVCApp.Controllers
{
    public class MDController : Controller
    {
        // GET: MD
        public ActionResult Home(MDirector ho)
        {
            Session["MD"] = ho;
            Session["Id"] = ho.MD_Id;
            Session["Name"] = ho.MD_name;
            Session["Password"] = ho.MD_password;

            return RedirectToAction("HomePage");
        }

        public ActionResult Home1()
        {
            return View(Session["MD"]);
        }

        [HttpGet]
        public ActionResult ManagerSalary()
        {
            BranchManagerRepository brepo = new BranchManagerRepository();
            List<BranchManager> blist = brepo.GetAll();
            return View(blist);
        }

        [HttpPost,ActionName("ManagerSalary")]
        public ActionResult ConfirmManagerSalary(int Manager_Id)
        {
            BranchManagerRepository brepo = new BranchManagerRepository();
            BranchManager br = brepo.Get(Manager_Id);
            DateTime d = DateTime.Today;

            if (d>= Convert.ToDateTime(br.Manager_LastPaymentDate).AddDays(30))
            {
                br.Manager_LastPaymentDate = d.ToString();
                br.Manager_TotalPayment += br.Manager_Salary;
                br.Manager_Balance += br.Manager_Salary;

                brepo.Update(br);
                ViewData["Message"] = "Salary Payment Successfull";

                TransactionRepository trepo = new TransactionRepository();
                Transaction tr = new Transaction();
                tr.Tr_Amount = br.Manager_Salary;
                tr.Tr_Date = DateTime.Now.ToString("yyyy-MM-dd");
                tr.Tr_EmpType = "MD";
                tr.Tr_AccName = br.Manager_Name;
                tr.Tr_Through = Session["Name"].ToString();
                tr.Tr_Type = "Salary";

                trepo.Insert(tr);

            }
            else
            {
                ViewData["Message"] = "To Early to Pay Salary";
            }
            
            return View("Empty");
        }

        public ActionResult ManagerDetails()
        {
            BranchManagerRepository brepo = new BranchManagerRepository();
            List<BranchManager> blist = brepo.GetAll();
            return View(blist);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View(Session["MD"]);
        }

        [HttpPost, ActionName("EditProfile")]
        public ActionResult ConfirmEditProfile(MDirector md)
        {
            MDirectorRepository mrepo = new MDirectorRepository();
            mrepo.Update(md);

            ViewData["Message"] = "Edit Successfull";
            Session["MD"] = md;
            return View("Empty");

        }
        [HttpGet]
        public ActionResult PendingLoans()
        {
            LoanRepository lrepo = new LoanRepository();
            List<LInfo> ll = lrepo.GetAllNoapprovalfromMD();
            return View(ll);
        }

        [HttpPost, ActionName("PendingLoans")]
        public ActionResult ConfirmPendingLoans(int Loan_Id)
        {
            LoanRepository brepo = new LoanRepository();
            LInfo br = brepo.Get(Loan_Id);
            br.MD_Approval = "Yes";
            br.Status = "Active";

            brepo.MD_Approval_Update(br);
            ViewData["Message"] = "Your Apporaval Is Successfully Done";

            return View("Empty");
        }

        public ActionResult Annual_Repots()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.GetCurrentYear();
            return View(ll);
        }

        public ActionResult Todays_Transcation()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.GetToday();
            return View(ll);
        }

        public ActionResult Yestarday_Transcation()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.GetYesterday();
            return View(ll);
        }

        public ActionResult Last_6_Month_Transcation()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.Get6Months();
            return View(ll);
        }

        [HttpGet]
        public ActionResult HomePage()
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByPos("MD"));
        }

        public ActionResult MyProfile(string Tr_Through)
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByEmp(Session["Name"].ToString()));
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, ActionName("ChangePassword")]
        public ActionResult ConfirmChangePassword(string oldpass, string Pass, string cpass)
        {
            MDirectorRepository orepo = new MDirectorRepository();
            LoginRepository lrepo = new LoginRepository();

            MDirector of = orepo.Get(Convert.ToInt32(Session["Id"]));

            Logininfo log = lrepo.Get(Session["Name"].ToString());

            if (Session["Password"].ToString() == oldpass)
            {
                if (Pass != cpass)
                {
                    ViewData["Message"] = "Password Didn't match";
                }
                else
                {
                    of.MD_password = Pass;
                    log.Login_Password = Pass;

                    orepo.Update(of);
                    lrepo.Update(log);

                    ViewData["Message"] = "Password Updated Successfully";
                    Session["MD"] = of;
                    Session["Password"] = Pass;

                }
            }
            else
            {
                ViewData["Message"] = "Wrong Password";
            }

            return View("Empty");
        }

        [HttpGet]
        public ActionResult Report()
        {
            TransactionRepository trepo = new TransactionRepository();
            return View(trepo.GetCurrentYear());
        }


        [HttpPost, ActionName("Report")]
        public ActionResult ConfirmReport(Transaction Transaction)
        {
            TransactionRepository trepo = new TransactionRepository();


            MVCApp.Report.AnnualReport AnnualReport = new MVCApp.Report.AnnualReport();
            byte[] abytes = AnnualReport.PrepareReport(trepo.GetCurrentYear());
            return File(abytes, "application/pdf");

        }

        ///Ja_b_report
        [HttpGet]
        public ActionResult Half_Year_Repot()
        {
            BranchRepository trepo = new BranchRepository();
            List<Branch> ll = trepo.GetAll();
            return View(ll);
        }
        ///Ja_b_report
        [HttpPost, ActionName("Half_Year_Repot")]
        public ActionResult Confirm_Half_Year_Repot(string Emp_branch)
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.Get6Months(Emp_branch);

            return View("Confirm_Half_Year_Repot_show", ll);
        }

        ///Ja_b_report
        [HttpGet]
        public ActionResult Annual_Repots_md_show()
        {
            BranchRepository trepo = new BranchRepository();
            List<Branch> ll = trepo.GetAll();
            return View(ll);
        }
        ///Ja_b_report
        [HttpPost, ActionName("Annual_Repots_md_show")]
        public ActionResult Confirm_Annual_Repots(string Emp_branch)
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.GetCurrentYear(Emp_branch);

            return View("Confirm_Annual_Repots_md_show", ll);
        }

    }
}