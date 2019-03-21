using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebApplication.Models
{
    public class DomainModel
    {
        public Actor Actor { get; set; }
        public Category Category { get; set; }
        public Movie Movie { get; set; }
        public RecommendedMovie RecommendedMovie { get; set; }
        public SavedMovie SavedMovie { get; set; }
        public Domain.User User { get; set; }
        public WatchedMovie WatchedMovie { get; set; }
    }
}