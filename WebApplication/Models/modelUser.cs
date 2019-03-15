using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebApplication.Models
{
    public class ModelUser
    {
        public string Password { get; set; }
        public string UserName { get; set; }

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public ModelUser AsignDomainUser(Domain.User user)
        {
            ModelUser muser = new ModelUser();
            muser.Password = user.Password;
            muser.UserName = user.UserName;
            muser.UserID = user.UserID;
            muser.Name = user.Name;
            muser.Surname = user.Surname;
            muser.Email = user.Email;
            muser.BirthDate = user.BirthDate;

            return muser;
        }
    }
}