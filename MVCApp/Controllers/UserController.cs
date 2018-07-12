using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRepository;


namespace MVCApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Home(User ho)
        {
            Session["User"] = ho;
            Session["User_acc_no"] = ho.User_acc_no;
            Session["User_Name"] = ho.User_Name;
            Session["Password"] = ho.User_password;
            Session["Account Type"] = ho.User_acc_type;
            return RedirectToAction("Home1");
        }

        public ActionResult Home1()
        {
            return View(Session["User"]);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View(Session["User"]);
        }

        [HttpPost, ActionName("EditProfile")]
        public ActionResult ConfirmEditProfile(User u)
        {
            UserRepository urepo = new UserRepository();
            urepo.Update(u);

            ViewData["Message"] = "Edit Successfull";
            Session["User"] = u;
            return View("Empty");

        }

        [HttpGet]
        public ActionResult TransferBalance()
        {
            return View(Session["User"]);
        }

        [HttpPost, ActionName("TransferBalance")]
        public ActionResult ConfirmTransferBalance(string name, int id, int amount)
        {

            UserRepository urepo1 = new UserRepository();
            User tfrom = urepo1.Get(Convert.ToInt32(Session["User_acc_no"]));
            User tto = urepo1.Get(id);



            if (tfrom.User_balance > amount + 1000 && tto.User_acc_type=="Savings")
            {

                tfrom.User_balance -= amount;
                tto.User_balance += amount;
                urepo1.Update(tfrom);
                urepo1.Update(tto);



                Session["User"] = tfrom;
            }
            else
            {

            }
            return View("Empty");
        }



        [HttpGet]
        public ActionResult CheckBook()
        {   

            if(Session["Account Type"].ToString()== "Savings")
            {
                string date = (DateTime.Today).ToString();
                ViewData["Message"] = date;
            }else
            {
                ViewData["Message"] = "Option not available";
            }

            
            return View("Empty");
        }
        [HttpPost, ActionName("CheckBook")]
        public ActionResult CheckBookcon(CheckBook u)
        {
            CheckBookRepository crepo = new CheckBookRepository();
            crepo.Insert(u);
            ViewData["Message"] = "Requeted Successfull";
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
            UserRepository orepo = new UserRepository();
            LoginRepository lrepo = new LoginRepository();

            User of = orepo.Get(Convert.ToInt32(Session["User_acc_no"]));

            Logininfo log = lrepo.Get(Session["User_Name"].ToString());

            if (Session["Password"].ToString() == oldpass)
            {
                if (Pass != cpass)
                {
                    ViewData["Message"] = "Password Didn't match";
                }
                else
                {
                    of.User_password = Pass;
                    log.Login_Password = Pass;

                    orepo.Update(of);
                    lrepo.Update(log);

                    ViewData["Message"] = "Password Updated Successfully";
                    Session["User"] = of;
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
