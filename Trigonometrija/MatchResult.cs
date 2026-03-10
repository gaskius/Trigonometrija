using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigonometrija.App_Code
{
    public class MatchResult
    {
        public string RectName { get; set; }
        public string TriName { get; set; }
        public string Description { get; set; }

        public MatchResult(string r, string t, string d)
        {
            this.RectName = r; this.TriName = t; this.Description = d;
        }
    }
}