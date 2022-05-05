using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieDb.Model.Movies
{

    public class Movie
    {
        public string MovieName;
        //Info about the movie
        public string IAM;
        public string CreatorName;
        public Movie()
        {

        }
        protected Movie(string movieName, string iAM, string creatorName)
        {
            MovieName = movieName;
            IAM = iAM;
            CreatorName = creatorName;
        }

        public virtual string SpecialCreator(string creatorName)
        {
            return creatorName;
        }
    }
}
