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
        
        // GET: User
        public ActionResult UserIndex(int userID)
        {
            #region ALTERNATIVA 1
            //Domain.User user = sql.LoadUser(userID);
            //List<Domain.Movie> lm = sql.LoadMovies();
            //ModelUser muser = new ModelUser();
            //muser = muser.AsignDomainUser(user);
            //return View(muser);
            #endregion

            #region ALTERNATIVA 2 (Error)
            //Domain.User user = sql.LoadUser(userID);
            //List<Domain.Movie> lm = sql.LoadMovies();

            ////muser = muser.AsignDomainUser(user);
            //object @object = new { User = user, MovieList = lm };
            //return View(@object);
            #endregion

            #region ALTERNATIVA 3
            DomainModel dm = new DomainModel();
            dm.User = sql.LoadUser(userID);
            return View(dm.User);
            #endregion            
        }
    }
}