using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SavedMovie : Movie
    {
        public SavedMovie()
        {
        }
        public SavedMovie(int movieID, string name, string description, List<Actor> cast, string director, List<Category> categories, DateTime releaseDate, float rating, string runningTime, string ageRestriction, string posterLink)
        {
        }
    }
}
