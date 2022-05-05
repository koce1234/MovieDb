using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieDb.Model.Movies
{

    public class ComedyMovie : Movie
    {
        private string SpecialJoke;
        public ComedyMovie()
        {

        }
        public ComedyMovie(string movieName, string iAM, string creatorName, string sj) : base(movieName, iAM, creatorName)
        {
            this.SpecialJoke = sj;
        }
        public override string ToString()
        {
            return this.IAM;
        }
        public override string SpecialCreator(string creatorName)
        {
            return $"The special creator in the comedy movie is {creatorName}  and the special joke is ,{SpecialJoke}";
        }
    }
}
