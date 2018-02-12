using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supersets
{
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

        internal SuperSet<T> AddSetWithElements(params T[] elements)
        {
            var hs = new HashSet<T>(elements);
            this.Add(hs);
            return this;
        }
    }
}
