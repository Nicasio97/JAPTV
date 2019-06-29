using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class WatchedMovie : Movie
    {
        public DateTime WatchedDate;
        public int UserRating;

        public WatchedMovie()
        {
        }
        public WatchedMovie(int movieID, string name, string description, List<Actor> cast, string director, List<Category> categories, DateTime releaseDate, float rating, string runningTime, string ageRestriction, string posterLink, string PosterLink, DateTime watchedDate, int userRating) : base(movieID, name, description, cast, director, categories, releaseDate, rating, runningTime, ageRestriction, posterLink)
        {
            WatchedDate = watchedDate;
            UserRating = userRating;
        }
    }
}
