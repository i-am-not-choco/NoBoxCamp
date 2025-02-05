
using Exiled.API.Interfaces;

namespace NoBoxCamp
{

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; }

        public  double HigherX { get; set; } = 51.405;
        public  double LowerX { get; set; } = 49.084;
        public  double HigherZ { get; set; } = -46.644;
        public  double LowerZ { get; set; } = -48.691;

        public int timeinboxallowed { get; set; } = 60;

        public bool showhowmuchtimeisleftwhileinbox { get; set; } = true;
        
        public float  dampersec { get; set; } = 10;

        public string deathmsg { get; set; } = "boxed";





    }
}