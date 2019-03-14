﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecommendedMovie : Movie
    {
        public RecommendedMovie()
        {
        }
        public RecommendedMovie(int movieID, string name, string description, List<Actor> cast, string director, List<Category> categories, DateTime releaseDate, float rating, int runningTime, string ageRestriction) : base(movieID, name, description, cast, director, categories, releaseDate, rating, runningTime, ageRestriction)
        {
        }
    }
}