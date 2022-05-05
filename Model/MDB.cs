using movieDb.Model.Movies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace movieDb.Model
{
    public class MDB
    {
        private const string amName = "ActionMoviesST";
        private const string cmName = "ComedyMoviesST";
        private const string dmName = "DramaMoviesST";


        private const string amp = @"C:\Users\me\Desktop\курсова работа\Data\ActionMoviesST.txt";
        private const string cmp = @"C:\Users\me\Desktop\курсова работа\Data\ComedyMoviesST.txt";
        private const string dmp = @"C:\Users\me\Desktop\курсова работа\Data\DramaMoviesST.txt";

        private string amp1 = Path.GetFullPath(amName);
        private string cmp1 = Path.GetFullPath(cmName);
        private string dmp1 = Path.GetFullPath(dmName);



        public List<ActionMovie> ActionMovies { get; set; }
        public List<DramaMovie> DramaMovies { get; set; }
        public List<ComedyMovie> ComedyMovies { get; set; }
        
        public MDB()
        {
            LoadMovies();
        }

        protected bool Check(string movieName) =>
            ActionMovies.FirstOrDefault(m => m.MovieName == movieName) != null
                || DramaMovies.FirstOrDefault(m => m.MovieName == movieName) != null
                || ComedyMovies.FirstOrDefault(m => m.MovieName == movieName) != null;


        public void AddMovie(string ganre, string movieName, string iAM, string creatorName, string ss)
        {
            if (Check(movieName))
            {
                Console.WriteLine("This movie name is taken");
                return;
            }
            if (ganre.ToLower() == "comedy")
            {
                var cm = new ComedyMovie(movieName, iAM, creatorName, ss);
                ComedyMovies.Add(cm);
               

            }
            else if (ganre.ToLower() == "drama")
            {
                var dm = new DramaMovie(movieName, iAM, creatorName, ss);
                DramaMovies.Add(dm);
                
            }
            else if (ganre.ToLower() == "action")
            {
                var am = new ActionMovie(movieName, iAM, creatorName, ss);
                ActionMovies.Add(am);
                

            }
            //throw error
        }

        public void RemoveMovieByN(string movieName)
        {
            var amovie = ActionMovies.FirstOrDefault(x => x.MovieName == movieName);
            var dmovie = DramaMovies.FirstOrDefault(x => x.MovieName == movieName);
            var cmovie = ComedyMovies.FirstOrDefault(x => x.MovieName == movieName);

            if (amovie == null && dmovie == null && cmovie == null)
            {
               //throw error 
            }
            else
            {
                ActionMovies.Remove(amovie);
                DramaMovies.Remove(dmovie);
                ComedyMovies.Remove(cmovie);
            }
        }

        public List<string> SearchMovieByName(string movieName)
        {
            
            
            var resultlist = new List<string>();
            foreach (var am in ActionMovies)
            {
                if (am.MovieName.ToLower().StartsWith(movieName.ToLower()))
                {
                    resultlist.Add(am.MovieName);
                }
            }
            foreach (var dm in DramaMovies)
            {
                if (dm.MovieName.ToLower().StartsWith(movieName.ToLower()))
                {
                    resultlist.Add(dm.MovieName);
                }
            }
            foreach (var cm in ActionMovies)
            {
                if (cm.MovieName.ToLower().StartsWith(movieName.ToLower()))
                {
                    resultlist.Add(cm.MovieName);
                }
            }
            return resultlist;
        }

        public List<string> SearchMoviesByCreatorName(string creatorName)
        {
            List<string> allf = new List<string>();
            foreach (var am in ActionMovies.Where(m => m.CreatorName == creatorName).ToList())
            {
                allf.Add(am.MovieName);
            }
            foreach (var dm in DramaMovies.Where(m => m.CreatorName == creatorName).ToList())
            {
                allf.Add(dm.MovieName);

            }
            foreach (var cm in ComedyMovies.Where(m => m.CreatorName == creatorName).ToList())
            {
                allf.Add(cm.MovieName);
            }
            return allf;
        }

        public void WriteMovie()
        {
                using (StreamWriter outputFile = new StreamWriter(cmp))
                {
                    foreach (var comedyMovie in ComedyMovies)
                    {
                        outputFile.Write($"|{comedyMovie.MovieName}.{comedyMovie.CreatorName}.{comedyMovie.IAM}.{comedyMovie.SpecialCreator(comedyMovie.CreatorName)}|");
                    }
                    
                }
            using (StreamWriter outputFile = new StreamWriter(dmp))
            {
                foreach (var dramaMovie in DramaMovies)
                {
                    outputFile.Write($"|{dramaMovie.MovieName}.{dramaMovie.CreatorName}.{dramaMovie.IAM}.{dramaMovie.SpecialCreator(dramaMovie.CreatorName)}|");
                }
            }
                using (StreamWriter outputFile = new StreamWriter(amp))
                {
                foreach (var actionMovie in ActionMovies)
                {
                    outputFile.Write($"|{actionMovie.MovieName}.{actionMovie.CreatorName}.{actionMovie.IAM}.{actionMovie.SpecialCreator(actionMovie.CreatorName)}|");
                }
                }
        }

        public void LoadMovies()
        {
            string ctext = File.ReadAllText(cmp);
            var raw = ctext.Split('|').Where(r => r!="");
            ActionMovies = new List<ActionMovie>();
            DramaMovies = new List<DramaMovie>();
            ComedyMovies = new List<ComedyMovie>();
            foreach (var cr in raw)
            {
                var items = cr.Split('.');
                var ss = items[3].Split(',');
                ComedyMovies.Add(new ComedyMovie(items[0],items[2],items[1],ss[1]));
            }

            string dtext = File.ReadAllText(dmp);
            var raw1 = dtext.Split('|').Where(r => r != "");

            foreach (var dr in raw1)
            {
                var items = dr.Split('.');
                var ss = items[3].Split(',');
                DramaMovies.Add(new DramaMovie(items[0], items[2], items[1], ss[1]));
            }

            string atext = File.ReadAllText(amp);
            var raw2 = atext.Split('|').Where(r => r != "");

            foreach (var ar in raw2)
            {
                var items = ar.Split('.');
                var ss = items[3].Split(',');
                ActionMovies.Add(new ActionMovie(items[0], items[2], items[1], ss[1]));
            }
        }

        public List<string> SearchMoviesByGanre(string ganre)
        {
            if (ganre.ToLower() == "action")
            {
                return ActionMovies.Select(a => a.MovieName).ToList();
            }
            if (ganre.ToLower() == "comedy")
            {
                return ComedyMovies.Select(a => a.MovieName).ToList();
            }
            if (ganre.ToLower() == "drama")
            {
                return DramaMovies.Select(a => a.MovieName).ToList();
            }
            return null;
        }

        public void RemoveMovieByCN(string cn)
        {
            ComedyMovies.RemoveAll(cm => cm.CreatorName == cn);
            DramaMovies.RemoveAll(dm => dm.CreatorName == cn);
            ActionMovies.RemoveAll(am => am.CreatorName == cn);
        }

    }
}




