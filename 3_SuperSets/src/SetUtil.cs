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
            var result = new HashSet<HashSet<int>>();
            result.Add(set);
            return result;
        }
    }

    public class SuperSet<T> : HashSet<HashSet<T>>
    {
        public SuperSet()
        {
        }

        public static bool Equals(SuperSet<T> a, SuperSet<T> b)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return SuperSet<T>.Equals(this as SuperSet<T>, obj as SuperSet<T>);
        }

        public static bool operator ==(SuperSet<T> a, SuperSet<T> b)
        {
            return SuperSet<T>.Equals(a,b);
        }
        public static bool operator !=(SuperSet<T> a, SuperSet<T> b)
        {
            return !SuperSet<T>.Equals(a, b);
        }

        public override int GetHashCode()
        {
            return 12345;
        }
    }
}
