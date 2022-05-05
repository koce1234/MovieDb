using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieDb.Model.Movies
{
    public class ActionMovie : Movie
    {
        private string SpecialShotingScene;
        public ActionMovie()
        {

        }
        public ActionMovie(string movieName, string iAM, string creatorName, string sss) : base(movieName, iAM, creatorName)
        {
            this.SpecialShotingScene = sss;
        }
        public override string ToString()
        {
            return this.IAM;
        }
        public override string SpecialCreator(string creatorName)
        {
            return $"The special star in the action movie is {creatorName} and the best shoting scene is ,{SpecialShotingScene}";
        }
    }
}
