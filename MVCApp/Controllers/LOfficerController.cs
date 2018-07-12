using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCRepository;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class LOfficerController : Controller
    {
        // GET: LOfficer
        public ActionResult Home(LoanOfficer ho)
        {
            Session["LoanOfficer"] = ho;
            Session["Id"] = ho.LOfficer_Id;
            Session["Name"] = ho.LOfficer_name;
            Session["Branch"] = ho.LOfficer_branch;
            Session["Password"] = ho.LOfficer_Password;

            return RedirectToAction("HomePage");
        }

        public ActionResult Home1()
        {
            return View(Session["LoanOfficer"]);
        }

        [HttpGet]
        public ActionResult CreateLoanAccount()
        {
            return View();
        }
        [HttpPost, ActionName("CreateLoanAccount")]
        public ActionResult ConfirmCreateLoanAccount(string User_Name, string User_password, string User_address, string User_mobile, string User_acc_type, double Loan_Amount, double Interest_Rate, int Loan_Deadline,string LoanCause)
        {
            LoginRepository lrepo = new LoginRepository();
            Logininfo li = lrepo.Get(User_Name);
            if (li == null)
            {
                User us = new User();
                us.User_acc_type = User_acc_type;
                us.User_address = User_address;
                us.User_balance = 0;
                us.User_mobile = User_mobile;
                us.User_Name = User_Name;
                us.User_password = User_password;
                us.Deadline = DateTime.Now.AddYears(Loan_Deadline).ToString("yyyy-MM-dd");

                LInfo loan = new LInfo();
                loan.LoanCause = LoanCause;
                loan.Loan_Amount = Loan_Amount;
                loan.Loan_Deadline = DateTime.Now.AddYears(Loan_Deadline).ToString("yyyy-MM-dd");
                loan.Interest_Rate =Interest_Rate;
                loan.AmountTo_Pay = loan.Loan_Amount + ((loan.Loan_Amount * loan.Interest_Rate) / 100);
                loan.Status = "Unapproved";
                loan.Loan_Amount_Paid = 0;
                loan.Loan_Date = DateTime.Now.ToString("yyyy-MM-dd");
                loan.Manager_Approval = "No";
                loan.MD_Approval = "No";
                loan.LOfficer_Id = Convert.ToInt32(Session["Id"]);
                loan.Loan_Branch = Session["Branch"].ToString();

                LoanRepository loanrepo = new LoanRepository();

                loanrepo.Insert(loan,us);


                ViewData["Message"] = "Loan Account Successfully Created";

                TransactionRepository trepo = new TransactionRepository();
                Transaction tr = new Transaction();
                tr.Tr_Amount = Loan_Amount;
                tr.Tr_Date = DateTime.Now.ToString("yyyy-MM-dd");
                tr.Tr_EmpType = "LOfficer";
                tr.Tr_AccName = us.User_Name;
                tr.Tr_Through = Session["Name"].ToString();
                tr.Tr_Type = "Loan";
                tr.Tr_Branch = Session["Branch"].ToString();

                trepo.Insert(tr);

                return View("Empty");
            }
            else
            {
                ViewData["Message"] = "Username in User/Invalid Info";
                return View("Empty");
            }

        }
        public ActionResult AllLoanAccount()
        {
            LoanRepository lrepo = new LoanRepository();
            List<LInfo> ll= lrepo.GetAll();
            return View(ll);
        }

        public ActionResult Unapproved()
        {
            LoanRepository lrepo = new LoanRepository();
            List<LInfo>  ll= lrepo.GetAllUnapproved();
            return View(ll);
        }
        public ActionResult Active()
        {
            LoanRepository lrepo = new LoanRepository();
            List<LInfo> ll = lrepo.GetAllActive();
            return View(ll);
        }
        public ActionResult InActive()
        {
            LoanRepository lrepo = new LoanRepository();
            List<LInfo> ll = lrepo.GetAllInActive();
            return View(ll);
        }

        [HttpGet]
        public ActionResult HomePage()
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByPos("LOfficer"));
        }

        public ActionResult MyProfile(string Tr_Through)
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByEmp(Session["Name"].ToString()));
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View(Session["LoanOfficer"]);
        }

        [HttpPost, ActionName("EditProfile")]
        public ActionResult ConfirmEditProfile(LoanOfficer l)
        {
            LORepository urepo = new LORepository();
            urepo.Update(l);

            ViewData["Message"] = "Edit Successfull";
            Session["LoanOfficer"] = l;
            return View("Empty");

        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, ActionName("ChangePassword")]
        public ActionResult ConfirmChangePassword(string oldpass, string Pass, string cpass)
        {
            LORepository orepo = new LORepository();
            LoginRepository lrepo = new LoginRepository();

            LoanOfficer of = orepo.Get(Convert.ToInt32(Session["Id"]));

            Logininfo log = lrepo.Get(Session["Name"].ToString());

            if (Session["Password"].ToString() == oldpass)
            {
                if (Pass != cpass)
                {
                    ViewData["Message"] = "Password Didn't match";
                }
                else
                {
                    of.LOfficer_Password = Pass;
                    log.Login_Password = Pass;

                    orepo.Update(of);
                    lrepo.Update(log);

                    ViewData["Message"] = "Password Updated Successfully";
                    Session["Officer"] = of;
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