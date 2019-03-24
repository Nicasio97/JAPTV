using DataAccess;
using System;
using System.Web.Mvc;
using Entities.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        SqlDataAccess2 sql = new SqlDataAccess2();
        
        // GET: Account
        public ActionResult LogIn(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult LogInCheck(string userName, string password)
        {
            if (!(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)))
            {
                User user = sql.LoadUser(userName, password);

                if (!string.IsNullOrWhiteSpace(user.UserName))
                {
                    Session["UserName"] = user.UserName;
                    Session["UserID"] = user.UserID;                    
                    return RedirectToAction("UserIndex", "User");
                }
                else
                {                    
                    return RedirectToAction("LogIn", "Account", new { message = "Incorrect username or password" });
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Account", new { message = "Please, don't leave empty boxes" });
            }            
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignOff()
        {
            Session["UserName"] = null;
            Session["UserID"] = null;
            return RedirectToAction("Index","Home");
        }
    }
}