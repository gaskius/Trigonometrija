using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trigonometrija.App_Code
{
    /// <summary>
    /// Represents a match between rectangle and triangle
    /// </summary>
    public class MatchResult
    {
        public string RectName { get; set; }
        public string TriName { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// The basic constructor for the MatchResult class, which 
        /// initializes the properties with the provided values.
        /// </summary>
        public MatchResult(string r, string t, string d)
        {
            this.RectName = r; this.TriName = t; this.Description = d;
        }
        /// <summary>
        /// Comares the current instance with another MatchResult object 
        /// for sorting purposes.
        /// </summary>
        public int CompareTo(MatchResult other)
        {
            if (other == null) return 1;

            int res = string.Compare(this.TriName, other.TriName);
            if (res != 0) return res;

            return string.Compare(this.RectName, other.RectName);
        }
    }
}