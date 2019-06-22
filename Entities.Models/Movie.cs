using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Actor> Cast { get; set; }
        public string Director { get; set; }
        public List<Category> Categories { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rating { get; set; }
        public string RunningTime { get; set; }
        public string AgeRestriction { get; set; } //List

        public Movie() { }
        public Movie(int movieID, string name, string description, List<Actor> cast, string director, List<Category> categories, DateTime releaseDate, float rating, string runningTime, string ageRestriction)
        {
            MovieID = movieID;
            Name = name;
            Description = description;
            Cast = cast;
            Director = director;
            Categories = categories;
            ReleaseDate = releaseDate;
            Rating = rating;
            RunningTime = runningTime;
            AgeRestriction = ageRestriction;
        }

        #region ToString()
        //public override string ToString()
        //{
        //    return String.Format("{0}", Name);
        //}
        #endregion

        #region MovieList
        //public List<Movie> _movies;
        //public List<Movie> Movies
        //{
        //    get
        //    {
        //        if (_movies == null)
        //            _movies = new List<Movie>();

        //        return _movies;
        //    }

        //    set
        //    {
        //        _movies = value;
        //    }
        //}
        #endregion        
    }
}
