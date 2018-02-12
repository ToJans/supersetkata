using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supersets
{
    public class SetUtil
    {
        /// <summary>
        ///  Supersets geeft van de gegeven set integers een set terug met de mogelijke combinaties van elk van de elementen. De volgorde van 
	    /// het resultaat is hierbij niet belangrijk.
	    /// 
	    /// bvb (1 2 3) => (() (1) (2) (3) (1 2) (1 3) (2 3) (1 2 3))
        /// </summary>
        /// <param name="set">de set om de powerset van te berekenen</param>
        /// <returns>powerset man de gegeven set</returns>
        public static HashSet<HashSet<int>> superSets(HashSet<int> set)
        {
            throw new NotImplementedException("Implement me!");
        }
    }
}
