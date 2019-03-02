using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPTV_Objects
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
        public int RunningTime { get; set; }
        public string AgeRestriction { get; set; } //List

        public Movie() { }
        public Movie(int movieID, string name, string description, List<Actor> cast, string director, List<Category> categories, DateTime releaseDate, float rating, int runningTime, string ageRestriction)
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
    }
}
