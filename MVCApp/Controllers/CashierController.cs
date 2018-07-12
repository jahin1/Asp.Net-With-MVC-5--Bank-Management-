using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRepository;

namespace MVCApp.Controllers
{
    public class CashierController : Controller
    {

        public ActionResult Home(Cashier cs)
        {
            Session["Cashier"] = cs;
            Session["Name"] = cs.Cashier_Name;
            Session["ID"] = cs.Cashier_Id;
            Session["Password"] = cs.Cashier_password;
            Session["Branch"] = cs.Cashier_branch;

            return RedirectToAction("HomePage");
        }

        public ActionResult Home1()
        {
            return View(Session["Cashier"]);
        }

        [HttpGet]
        public ActionResult CashWithdraw()
        {
            return View();
        }

        [HttpPost,ActionName("CashWithdraw")]
        public ActionResult ConfirmCashWithdraw(int accno,int amount,int conamount)
        {
            if (amount != conamount)
            {
                ViewData["Message"] = "Amount & Confirm Amount Didn't match";
            }else
            {
                UserRepository urepo = new UserRepository();
                User ur = urepo.Get(accno);

                if(ur.User_balance >= Convert.ToDouble(amount + 500) && amount>0 && ur.User_acc_type=="Savings")
                {
                    ur.User_balance = ur.User_balance - Convert.ToDouble(amount);
                    urepo.Update(ur);
                    ViewData["Message"] = "Withdrawal Successfull";

                    TransactionRepository trepo = new TransactionRepository();
                    Transaction tr = new Transaction();
                    tr.Tr_Amount = amount;
                    tr.Tr_Date = DateTime.Now.ToString("yyyy-MM-dd");
                    tr.Tr_EmpType = "Cashier";
                    tr.Tr_AccName = ur.User_Name;
                    tr.Tr_Through = Session["Name"].ToString();
                    tr.Tr_Type = "CashWithdraw";
                    tr.Tr_Branch = Session["Branch"].ToString();

                    trepo.Insert(tr);

                }
                else
                {
                    ViewData["Message"] = "Amount Is higher than available balance/Invalid";
                }
            }
            return View("Empty");
        }

        [HttpGet]
        public ActionResult CashDeposit()
        {
            return View();
        }

        [HttpPost,ActionName("CashDeposit")]
        public ActionResult ConfirmCashDeposit(int accno, int amount)
        {
            UserRepository urepo = new UserRepository();
            User ur = urepo.Get(accno);

            if (ur.User_acc_type == "Savings")
            {

                if (amount >= 1000)
                {
                    ur.User_balance = ur.User_balance + Convert.ToDouble(amount);
                    urepo.Update(ur);
                    ViewData["Message"] = "Deposit Successfull";

                    TransactionRepository trepo = new TransactionRepository();
                    Transaction tr = new Transaction();
                    tr.Tr_Amount = amount;
                    tr.Tr_Date = DateTime.Now.ToString("yyyy-MM-dd");
                    tr.Tr_EmpType = "Cashier";
                    tr.Tr_AccName = ur.User_Name;
                    tr.Tr_Through = Session["Name"].ToString();
                    tr.Tr_Type = "CashDeposit";
                    tr.Tr_Branch = Session["Branch"].ToString();

                    trepo.Insert(tr);

                }
                else
                {
                    ViewData["Message"] = "Amount has to be higher that 1000Tk/Invalid";
                }

            }else if(ur.User_acc_type == "Loan")
            {
                LoanRepository lr = new LoanRepository();
               
                LInfo luser = lr.GetUser(ur.User_acc_no);

                if(amount >= 1000 && luser.Status=="Active")
                {
                    luser.Loan_Amount_Paid += Convert.ToDouble(amount);
                    lr.Update(luser, ur);

                    if (luser.AmountTo_Pay == luser.Loan_Amount_Paid)
                    {
                        luser.Status = "InActive";
                        lr.Update(luser, ur);
                        ViewData["Message"] = "Loan Payment Successfull, Your Loan Account Has been Deactivated, Thank You, Sir. Come Again Soon!";
                    }
                }else
                {
                    ViewData["Message"] = "Amount has to be higher that 1000Tk/Invalid";
                }
                
            }else
            {
                ViewData["Message"] = "Account Not Recognized";
            }

            return View("Empty");
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View(Session["Cashier"]);
        }

        [HttpPost,ActionName("EditProfile")]
        public ActionResult ConfirmEditProfile(Cashier cs)
        {
            CashierRepository crepo = new CashierRepository();
            crepo.Update(cs);

               ViewData["Message"] = "Edit Successfull";
               Session["Cashier"] = cs;
               return View("Empty");

        }
        
        [HttpGet]
        public ActionResult FDAWithdraw()
        {   
            return View();
        }

        [HttpPost, ActionName("FDAWithdraw")]
        public ActionResult ConfirmFDAWithdraw(int accno, string name)
        {
            UserRepository urepo = new UserRepository();
            User urNo = urepo.Get(accno);
            User urNa = urepo.Get(name);

            if (urNo == urNa)
            {
                if (DateTime.Today >= Convert.ToDateTime(urNa.Deadline))
                {
                    double amount = urNa.User_balance;
                    urNa.User_balance = 0;
                    urepo.Update(urNa);
                    ViewData["Message"] = "Withdrawal Successfull";

                    TransactionRepository trepo = new TransactionRepository();
                    Transaction tr = new Transaction();
                    tr.Tr_Amount = amount;
                    tr.Tr_Date = DateTime.Now.ToString("yyyy-MM-dd");
                    tr.Tr_EmpType = "Cashier";
                    tr.Tr_AccName = urNa.User_Name;
                    tr.Tr_Through = Session["Name"].ToString();
                    tr.Tr_Type = "CashDeposit";
                    tr.Tr_Branch = Session["Branch"].ToString();

                    trepo.Insert(tr);

                }
                else
                {
                    ViewData["Message"] = "Cant Withdraw Yet";
                }
            }
            else
            {
                ViewData["Message"] = "Account No and Name Didn't Match";
            }
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
            CashierRepository orepo = new CashierRepository();
            LoginRepository lrepo = new LoginRepository();

            Cashier of = orepo.Get(Convert.ToInt32(Session["Id"]));

            Logininfo log = lrepo.Get(Session["Name"].ToString());

            if (Session["Password"].ToString() == oldpass)
            {
                if (Pass != cpass)
                {
                    ViewData["Message"] = "Password Didn't match";
                }
                else
                {
                    of.Cashier_password = Pass;
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

        [HttpGet]
        public ActionResult HomePage()
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByPos("Cashier"));
        }

        public ActionResult MyProfile(string Tr_Through)
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByEmp(Session["Name"].ToString()));
        }


    }
}