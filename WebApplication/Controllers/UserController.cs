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
        public ActionResult UserIndex(int userID)
        {
            User user = sql.LoadUser(userID);
            return View(user);
        }
    }
}