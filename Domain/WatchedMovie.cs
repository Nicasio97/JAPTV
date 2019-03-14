using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WatchedMovie : Movie
    {
        public DateTime WatchedDate;
        public int UserRating;

        public WatchedMovie()
        {
        }
        public WatchedMovie(int movieID, string name, string description, List<Actor> cast, string director, List<Category> categories, DateTime releaseDate, float rating, int runningTime, string ageRestriction, DateTime watchedDate, int userRating) : base(movieID, name, description, cast, director, categories, releaseDate, rating, runningTime, ageRestriction)
        {
            WatchedDate = watchedDate;
            UserRating = userRating;
        }
    }
}
