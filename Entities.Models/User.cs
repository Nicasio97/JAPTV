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
      
        private List<RecommendedMovie> _recommendedMovies;
        public List<RecommendedMovie> RecommendedMovies
        {
            get
            {
                if (_recommendedMovies == null)
                    _recommendedMovies = new List<RecommendedMovie>();

                return _recommendedMovies;
            }

            set
            {
                _recommendedMovies = value;
            }
        }

        private List<WatchedMovie> _watchedMovies;
        public List<WatchedMovie> WatchedMovies
        {
            get
            {
                if (_watchedMovies == null)
                    _watchedMovies = new List<WatchedMovie>();

                return _watchedMovies;
            }

            set
            {
                _watchedMovies = value;
            }
        }

        private List<SavedMovie> _savedMovies;
        public List<SavedMovie> SavedMovies
        {
            get
            {
                if (_savedMovies == null)
                    _savedMovies = new List<SavedMovie>();

                return _savedMovies;
            }

            set
            {
                _savedMovies = value;
            }
        }
    }
}
