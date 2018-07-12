using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRepository;

namespace MVCApp.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Home(BranchManager ho)
        {
            Session["Manager"] = ho;
            Session["Name"] = ho.Manager_Name;
            Session["Branch"] = ho.Manager_branch;
            Session["Password"] = ho.Manager_password;
            return RedirectToAction("HomePage");
        }

        public ActionResult Home1()
        {
            return View(Session["Manager"]);
        }


        public ActionResult Officer_details()
        {
            OfficerRepository orepo = new OfficerRepository();
            List<Officer> ll = orepo.GetAll();
            return View(ll);
        }


        public ActionResult Cashier_details()
        {
            CashierRepository orepo = new CashierRepository();
            List<Cashier> ll = orepo.GetAll();
            return View(ll);
        }


        public ActionResult LoanOfficer_details()
        {
            LORepository orepo = new LORepository();
            List<LoanOfficer> ll = orepo.GetAll();
            return View(ll);
        }




        [HttpGet]
        public ActionResult Officer_Salary()
        {
            OfficerRepository brepo = new OfficerRepository();
            List<Officer> blist = brepo.GetAll();

            List<Officer> slist = new List<Officer>();
            foreach (Officer of in blist)
            {
                if (of.Officer_branch != Session["Branch"].ToString())
                {

                }else
                {
                    slist.Add(of);
                }

            }

            return View(slist);
        }

        [HttpPost, ActionName("Officer_Salary")]
        public ActionResult ConfirmOfficer_Salary(int Officer_Id)
        {
            OfficerRepository brepo = new OfficerRepository();
            Officer br = brepo.Get(Officer_Id);
            DateTime d = DateTime.Now;

            if (d >= Convert.ToDateTime(br.Officer_LastPaymentDate).AddDays(30))
            {
                br.Officer_LastPaymentDate = d.ToString();
                br.Officer_TotalPayment += br.Officer_Salary;
                br.Officer_Balance += br.Officer_Salary;

                brepo.Update(br);
                ViewData["Message"] = "Salary Payment Successfull";
            }
            else
            {
                ViewData["Message"] = "To Early to Pay Salary";
            }

            return View("Empty");
        }



        [HttpGet]
        public ActionResult Cashier_Salary()
        {
            CashierRepository brepo = new CashierRepository();
            List<Cashier> blist = brepo.GetAll();

            List<Cashier> slist = new List<Cashier>();
            foreach (Cashier of in blist)
            {
                if (of.Cashier_branch != Session["Branch"].ToString())
                {

                }
                else
                {
                    slist.Add(of);
                }

            }

            return View(slist);
            
        }

        [HttpPost, ActionName("Cashier_Salary")]
        public ActionResult ConfirmCashier_Salary(int Cashier_Id)
        {
            CashierRepository brepo = new CashierRepository();
            Cashier br = brepo.Get(Cashier_Id);
            DateTime d = DateTime.Now;

            if (d >= Convert.ToDateTime(br.Cashier_LastPaymentDate).AddDays(30))
            {
                br.Cashier_LastPaymentDate = d.ToString();
                br.Cashier_TotalPayment += br.Cashier_Salary;
                br.Cashier_Balance += br.Cashier_Salary;

                brepo.Update(br);
                ViewData["Message"] = "Salary Payment Successfull";
            }
            else
            {
                ViewData["Message"] = "To Early to Pay Salary";
            }

            return View("Empty");
        }





        [HttpGet]
        public ActionResult LoanOfficer_Salary()
        {
            LORepository brepo = new LORepository();
            List<LoanOfficer> blist = brepo.GetAll();
            List<LoanOfficer> slist = new List<LoanOfficer>();

            foreach (LoanOfficer of in blist)
            {
                if (of.LOfficer_branch != Session["Branch"].ToString())
                {

                }
                else
                {
                    slist.Add(of);
                }

            }

            return View(slist);
        }

        [HttpPost, ActionName("LoanOfficer_Salary")]
        public ActionResult ConfirmLoanOfficer_Salary(int LOfficer_Id)
        {
            LORepository brepo = new LORepository();
            LoanOfficer br = brepo.Get(LOfficer_Id);
            DateTime d = DateTime.Now;

            if (d >= Convert.ToDateTime(br.LOfficer_LastPaymentDate).AddDays(30))
            {
                br.LOfficer_LastPaymentDate = d.ToString();
                br.LOfficer_TotalPayment += br.LOfficer_Salary;
                br.LOfficer_Balance += br.LOfficer_Salary;

                brepo.Update(br);
                ViewData["Message"] = "Salary Payment Successfull";
            }
            else
            {
                ViewData["Message"] = "To Early to Pay Salary";
            }

            return View("Empty");
        }


        [HttpGet]
        public ActionResult Pending_Loans()
        {
            LoanRepository lrepo = new LoanRepository();
            List<LInfo> ll = lrepo.GetAllNoapprovalfromManager(Session["Branch"].ToString());
            return View(ll);
        }

        [HttpPost, ActionName("Pending_Loans")]
        public ActionResult ConfirmPending_Loans(int Loan_Id)
        {
            LoanRepository brepo = new LoanRepository();
            LInfo br = brepo.Get(Loan_Id);
            br.Manager_Approval = "Yes";

            brepo.Manager_Approval_Update(br);
            ViewData["Message"] = "Your Apporaval Is Successfully Done";

            return View("Empty");
        }


        [HttpGet]
        public ActionResult Active_Loans()
        {
            LoanRepository lrepo = new LoanRepository();
            List<LInfo> ll = lrepo.GetAllActive();
            return View(ll);
        }

        public ActionResult Annual_Repots()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.GetCurrentYear(Session["Branch"].ToString());
            return View(ll);
        }

        public ActionResult Todays_Transcation()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.GetToday(Session["Branch"].ToString());
            return View(ll);
        }

        public ActionResult Yestarday_Transcation()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.GetYesterday(Session["Branch"].ToString());
            return View(ll);
        }

        public ActionResult Last_6_Month_Transcation()
        {
            TransactionRepository trepo = new TransactionRepository();
            List<Transaction> ll = trepo.Get6Months(Session["Branch"].ToString());
            return View(ll);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View(Session["Manager"]);
        }

        [HttpPost, ActionName("EditProfile")]
        public ActionResult ConfirmEditProfile(BranchManager u)
        {
            BranchManagerRepository urepo = new BranchManagerRepository();
            urepo.Update(u);

            ViewData["Message"] = "Edit Successfull";
            Session["Manager"] = u;
            return View("Empty");

        }

        [HttpGet]
        public ActionResult HomePage()
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByPos("Manager"));
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

            BranchManagerRepository orepo = new BranchManagerRepository();
            LoginRepository lrepo = new LoginRepository();

            BranchManager of = orepo.Get(Convert.ToInt32(Session["Id"]));

            Logininfo log = lrepo.Get(Session["Name"].ToString());

            if (Session["Password"].ToString() == oldpass)
            {
                if (Pass != cpass)
                {
                    ViewData["Message"] = "Password Didn't match";
                }
                else
                {
                    of.Manager_password = Pass;
                    log.Login_Password = Pass;

                    orepo.Update(of);
                    lrepo.Update(log);

                    ViewData["Message"] = "Password Updated Successfully";
                    Session["Manager"] = of;
                    Session["Password"] = Pass;

                }
            }
            else
            {
                ViewData["Message"] = "Wrong Password";
            }

            return View("Empty");
        }

    }
}