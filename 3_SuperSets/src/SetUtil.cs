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
            if (Object.ReferenceEquals(a, b)) { return true; }
            if (null == a || null == b) { return false; }
            if (a.Count != b.Count) { return false; }
            return a.All(setA => b.Any(setB => setA.SetEquals(setB)));
        }

        public override bool Equals(object obj)
        {
            return SuperSet<T>.Equals(this as SuperSet<T>, obj as SuperSet<T>);
        }

        public static bool operator ==(SuperSet<T> a, SuperSet<T> b)
        {
            return SuperSet<T>.Equals(a, b);
        }
        public static bool operator !=(SuperSet<T> a, SuperSet<T> b)
        {
            return !SuperSet<T>.Equals(a, b);
        }

        public override int GetHashCode()
        {
            var hashCode = 123456 ^ this.Count * 97;
            foreach (var set in this)
            {
                hashCode ^= set.Count * 13;
                foreach (var el in this)
                {
                    hashCode ^= el.GetHashCode();
                }
            }
            return hashCode;
        }

        internal SuperSet<T> AddSetWithElements(params T[] elements)
        {
            var hs = new HashSet<T>(elements);
            this.Add(hs);
            return this;
        }
    }
}
