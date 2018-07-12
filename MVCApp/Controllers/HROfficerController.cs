using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCRepository;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HROfficerController : Controller
    {
        // GET: HROfficer
        public ActionResult Home(HROfficer ho)
        {
            Session["HROfficer"] = ho;
            Session["Name"] = ho.HR_name;
            Session["Id"] = ho.HR_acc_Id;
            Session["Password"] = ho.HR_password;
            return RedirectToAction("HomePage");
        }

        public ActionResult Home1()
        {
            return View(Session["HROfficer"]);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            BranchRepository repo = new BranchRepository();
            
            return View(repo.GetAll());
        }

        [HttpPost,ActionName("AddEmployee")]
        public ActionResult ConfirmAddEmployee(string Emp_name,string Emp_password,string Emp_address,string Emp_mobile,double Emp_salary,string Emp_branch,string Emp_position)
        {
            LoginRepository lrepo = new LoginRepository();

            Logininfo li = lrepo.Get(Emp_name);

            if (li==null)
            {
                if (Emp_position == "HROfficer")
                {
                    HROfficerRepository repo = new HROfficerRepository();
                    HROfficer bm = new HROfficer();
                    bm.HR_address = Emp_address;
                    bm.HR_Balance = 0;
                    bm.HR_branch = Emp_branch;
                    bm.HR_LastPaymentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    bm.HR_mobile = Emp_mobile;
                    bm.HR_name = Emp_name;
                    bm.HR_password = Emp_password;
                    bm.HR_Salary = Emp_salary;
                    bm.HR_TotalPayment = 0;

                    repo.Insert(bm);
                }
                else if (Emp_position == "LOfficer")
                {
                    LORepository repo = new LORepository();
                    LoanOfficer bm = new LoanOfficer();
                    bm.LOfficer_address = Emp_address;
                    bm.LOfficer_Balance = 0;
                    bm.LOfficer_branch = Emp_branch;
                    bm.LOfficer_LastPaymentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    bm.LOfficer_mobile = Emp_mobile;
                    bm.LOfficer_name = Emp_name;
                    bm.LOfficer_Password = Emp_password;
                    bm.LOfficer_Salary = Emp_salary;
                    bm.LOfficer_TotalPayment = 0;

                    repo.Insert(bm);
                }
                else if (Emp_position == "Manager")
                {
                    BranchManagerRepository repo = new BranchManagerRepository();
                    BranchManager bm = new BranchManager();
                    bm.Manager_address = Emp_address;
                    bm.Manager_Balance = 0;
                    bm.Manager_branch = Emp_branch;
                    bm.Manager_LastPaymentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    bm.Manager_mobile = Emp_mobile;
                    bm.Manager_Name = Emp_name;
                    bm.Manager_password = Emp_password;
                    bm.Manager_Salary = Emp_salary;
                    bm.Manager_TotalPayment = 0;

                    repo.Insert(bm);
                }
                else if (Emp_position == "Cashier")
                {
                    CashierRepository repo = new CashierRepository();
                    Cashier bm = new Cashier();
                    bm.Cashier_address = Emp_address;
                    bm.Cashier_Balance = 0;
                    bm.Cashier_branch = Emp_branch;
                    bm.Cashier_LastPaymentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    bm.Cashier_mobile = Emp_mobile;
                    bm.Cashier_Name = Emp_name;
                    bm.Cashier_password = Emp_password;
                    bm.Cashier_Salary = Emp_salary;
                    bm.Cashier_TotalPayment = 0;

                    repo.Insert(bm);
                }
                else if (Emp_position == "Officer")
                {
                    OfficerRepository repo = new OfficerRepository();
                    Officer bm = new Officer();
                    bm.Officer_address = Emp_address;
                    bm.Officer_Balance = 0;
                    bm.Officer_branch = Emp_branch;
                    bm.Officer_LastPaymentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    bm.Officer_mobile = Emp_mobile;
                    bm.Officer_Name = Emp_name;
                    bm.Officer_password = Emp_password;
                    bm.Officer_Salary = Emp_salary;
                    bm.Officer_TotalPayment = 0;

                    repo.Insert(bm);
                }
                ViewData["Message"] = "Entry Successfull";
            }
            else
            {
                ViewData["Message"] = "Username in Use";
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
            HROfficerRepository orepo = new HROfficerRepository();
            LoginRepository lrepo = new LoginRepository();

            HROfficer of = orepo.Get(Convert.ToInt32(Session["Id"]));

            Logininfo log = lrepo.Get(Session["Name"].ToString());

            if (Session["Password"].ToString() == oldpass)
            {
                if (Pass != cpass)
                {
                    ViewData["Message"] = "Password Didn't match";
                }
                else
                {
                    of.HR_password = Pass;
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


            return View(urepo.GetByPos("HROfficer"));
        }

        public ActionResult MyProfile(string Tr_Through)
        {
            TransactionRepository urepo = new TransactionRepository();


            return View(urepo.GetByEmp(Session["Name"].ToString()));
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View(Session["HROfficer"]);
        }

        [HttpPost, ActionName("EditProfile")]
        public ActionResult ConfirmEditProfile(HROfficer l)
        {
            HROfficerRepository urepo = new HROfficerRepository();
            urepo.Update(l);

            ViewData["Message"] = "Edit Successfull";
            Session["HROfficer"] = l;
            return View("Empty");

        }
    }
}