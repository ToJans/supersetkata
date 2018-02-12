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
            this.Add(new HashSet<T>());
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
            foreach(var el in elements)
            {
                var existingsets = this.ToArray();
                foreach(var existingset in existingsets)
                {
                    if (!existingset.Contains(el))
                    {
                        var newSet = new HashSet<T>();
                        foreach (var val in existingset)
                        {
                            newSet.Add(val);
                        }
                        newSet.Add(el);
                        this.Add(newSet);
                    }
                }
            }
            return this;
        }
    }
}
