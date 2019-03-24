using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        public string Password { get; set; }
        public string UserName { get; set; }

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public User()
        {
        }
        public User(string password, string userName, int userID, string name, string surname, string email, DateTime birthDate)
        {
            Password = password;
            UserName = userName;
            UserID = userID;
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return String.Format("Name: {0} \r Surname: {1} \r Email: {2} \r BirthDate: {3}", Name, Surname, Email, BirthDate);
        }

        /*
         1)Is it better that the type of each list were from the type of the respective classes?
         2)It is better that the lists be in the model class of the web project than in this class?        
        */
        private List<Movie> _recommendedMovies;
        public List<Movie> RecommendedMovies
        {
            get
            {
                if (_recommendedMovies == null)
                    _recommendedMovies = new List<Movie>();

                return _recommendedMovies;
            }

            set
            {
                _recommendedMovies = value;
            }
        }

        private List<Movie> _watchedMovies;
        public List<Movie> WatchedMovies
        {
            get
            {
                if (_watchedMovies == null)
                    _watchedMovies = new List<Movie>();

                return _watchedMovies;
            }

            set
            {
                _watchedMovies = value;
            }
        }

        private List<Movie> _savedMovies;
        public List<Movie> SavedMovies
        {
            get
            {
                if (_savedMovies == null)
                    _savedMovies = new List<Movie>();

                return _savedMovies;
            }

            set
            {
                _savedMovies = value;
            }
        }
    }
}
