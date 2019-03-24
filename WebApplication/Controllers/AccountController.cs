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
            #region ALTERNATIVA 1
            //Domain.User user = new Domain.User();
            //string actionName = null;
            //string controllerName = null;
            //object @object = null;

            //if (!(String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password)))
            //{
            //    user = sql.LoadUser(userName, password);

            //    if (!(user.UserName == null || user.Password == null))
            //    {
            //        actionName = "UserIndex";
            //        controllerName = "User";
            //        @object = new { userID = user.UserID };
            //    }
            //    else
            //    {
            //        actionName = "LogIn";
            //        controllerName = "Account";
            //        @object = new { message = "Incorrect username or password" };
            //    }
            //}
            //else
            //{
            //    actionName = "LogIn";
            //    controllerName = "Account";
            //    @object = new { message = "Please, don't leave empty boxes" };
            //}

            //return RedirectToAction(actionName, controllerName, @object);
            #endregion

            #region ALTERNATIVA 3
             
            string actionName = null;
            string controllerName = null;
            object @object = null;

            if (!(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)))
            {
                User user = sql.LoadUser(userName, password);

                if (!string.IsNullOrWhiteSpace(user.UserName))
                {
                    actionName = "UserIndex";
                    controllerName = "User";
                    @object = new { userID = user.UserID };
                }
                else
                {
                    actionName = "LogIn";
                    controllerName = "Account";
                    @object = new { message = "Incorrect username or password" };
                }
            }
            else
            {
                actionName = "LogIn";
                controllerName = "Account";
                @object = new { message = "Please, don't leave empty boxes" };
            }

            return RedirectToAction(actionName, controllerName, @object);
        }

        public ActionResult SignIn()
        {
            return View();
        }
        #endregion
    }
}