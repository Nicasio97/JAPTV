using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using WebApplication.Models;
using Domain;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        SqlDataAccess2 sql = new SqlDataAccess2();
        ModelUser muser = new ModelUser();
        // GET: User
        public ActionResult UserIndex(int userID)
        {
            Domain.User user = sql.LoadUser(userID);
            muser = muser.AsignDomainUser(user);
            return View(muser);
        }
    }
}