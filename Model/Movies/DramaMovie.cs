using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieDb.Model.Movies
{
    public class DramaMovie : Movie
    {
        private string SpecialDramaScene;
        public DramaMovie()
        {

        }
        public DramaMovie(string movieName, string iAM, string creatorName, string sds) : base(movieName, iAM, creatorName)
        {
            this.SpecialDramaScene = sds;
        }
        public override string ToString()
        {
            return this.IAM;
        }
        public override string SpecialCreator(string creatorName)
        {
            return $"The special creator in the drama movie is {creatorName} and the special drama scene is ,{SpecialDramaScene}";
        }
    }
}
