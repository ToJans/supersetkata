using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using supersets;

namespace test
{
    [TestClass]
    public class SuperSetsTest
    {
        [TestMethod]
        public void superSetsOfEmptySet()
        {
            var expected = new HashSet<HashSet<int>>();
            expected.Add(new HashSet<int>());
            var actual = new SuperSet<int>();
            setEquals(actual, expected);
        }

        [TestMethod]
        public void emptySuperSetsAreEqual()
        {
            var leftSet = new SuperSet<int>();
            var rightSet = new SuperSet<int>();
            Assert.AreEqual(leftSet, rightSet);
        }

        [TestMethod]
        public void emptySetAndFilledSetAreNotEqual()
        {
            var leftSet = new SuperSet<int>();
            var rightSet = new SuperSet<int>().AddSetWithElements(1, 2);
            Assert.AreNotEqual(leftSet, rightSet);
        }

        [TestMethod]
        public void twoFilledSetsWithSameElementsAreEqual()
        {
            var leftSet = new SuperSet<int>().AddSetWithElements(1, 2);
            var rightSet = new SuperSet<int>().AddSetWithElements(1, 2);
            Assert.AreEqual(leftSet, rightSet);
        }

        [TestMethod]
        public void twoFilledSetsWithDifferentElementsAreNotEqual()
        {
            var leftSet = new SuperSet<int>().AddSetWithElements(1, 2);
            var rightSet = new SuperSet<int>().AddSetWithElements(1, 3);
            Assert.AreNotEqual(leftSet, rightSet);
        }

        [TestMethod]
        public void superSetsOfSingleElement()
        {
            HashSet<HashSet<int>> expected = new HashSet<HashSet<int>>();
            expected.Add(setWithElements());
            expected.Add(setWithElements(1));
            var actual = new SuperSet<int>()
                .AddSetWithElements(1);
            setEquals(actual, expected);
        }

        [TestMethod]
        public void superSetsOfSimpleSet()
        {
            HashSet<HashSet<int>> expected = new HashSet<HashSet<int>>();
            expected.Add(setWithElements());
            expected.Add(setWithElements(1));
            expected.Add(setWithElements(2));
            expected.Add(setWithElements(1, 2));

            var actual = new SuperSet<int>().AddSetWithElements(1, 2);

            setEquals(actual, expected);
        }

        [TestMethod]
        public void superSetsOfBiggerSet()
        {
            HashSet<HashSet<int>> expected = new HashSet<HashSet<int>>();
            expected.Add(setWithElements());
            expected.Add(setWithElements(1));
            expected.Add(setWithElements(2));
            expected.Add(setWithElements(3));
            expected.Add(setWithElements(1, 2));
            expected.Add(setWithElements(1, 3));
            expected.Add(setWithElements(2, 3));
            expected.Add(setWithElements(1, 2, 3));

            var actual = new SuperSet<int>().AddSetWithElements(1, 2, 3);

            setEquals(actual, expected);
        }

        [Ignore]
        [TestMethod]
        public void superSetsOfEvenBiggerSet()
        {
            HashSet<HashSet<int>> expected = new HashSet<HashSet<int>>();
            expected.Add(setWithElements());
            expected.Add(setWithElements(1));
            expected.Add(setWithElements(2));
            expected.Add(setWithElements(3));
            expected.Add(setWithElements(4));
            expected.Add(setWithElements(1, 2));
            expected.Add(setWithElements(1, 3));
            expected.Add(setWithElements(1, 4));
            expected.Add(setWithElements(2, 3));
            expected.Add(setWithElements(2, 4));
            expected.Add(setWithElements(3, 4));
            expected.Add(setWithElements(1, 2, 3));
            expected.Add(setWithElements(1, 2, 4));
            expected.Add(setWithElements(1, 3, 4));
            expected.Add(setWithElements(2, 3, 4));
            expected.Add(setWithElements(1, 2, 3, 4));

            //setEquals(expected, SetUtil.superSets(setWithElements(1, 2, 3, 4)));
        }

        private HashSet<int> setWithElements(params int[] elements)
        {
            HashSet<int> result = new HashSet<int>();
            foreach (int integer in elements)
            {
                result.Add(integer);
            }
            return result;
        }

        private void setEquals(SuperSet<int> actual, HashSet<HashSet<int>> expected)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (HashSet<int> set in expected)
            {
                bool inSet = false;
                foreach (HashSet<int> actualSet in actual)
                {
                    if (set.SetEquals(actualSet))
                    {
                        inSet = true;
                    }
                }
                Assert.IsTrue(inSet);
            }
        }

    }
}
