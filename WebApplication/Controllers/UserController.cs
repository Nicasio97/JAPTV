using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Entities.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        SqlDataAccess2 sql = new SqlDataAccess2();
        
        // GET: User
        public ActionResult UserIndex()
        {
            if (Session["UserID"] != null)
            {
                User user = sql.LoadUser((int)Session["UserID"]);
                return View(user);
            }
            else
            {
                object @object = new { message = "You have to Log In first" };
                return RedirectToAction("LogIn","Account",@object);
            }            
        }

        public ActionResult UserInfo()
        {
            return View();
        }

        public ActionResult YourMovies()
        {
            return View();
        }
    }
}