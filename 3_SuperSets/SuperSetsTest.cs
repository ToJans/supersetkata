﻿using System;
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
        [Ignore]
        [TestMethod]
        public void superSetsOfEmptySet() {
		    setEquals(new HashSet<HashSet<int>>(), SetUtil.superSets(new HashSet<int>()));
	    }
	
	    [Ignore]
        [TestMethod]
        public void superSetsOfSingleElement() {
            HashSet<HashSet<int>> expected = new HashSet<HashSet<int>>();
		    expected.Add(setWithElements());
		    expected.Add(setWithElements(1));
		    setEquals(expected, SetUtil.superSets(setWithElements(1)));
	    }

        [Ignore]
        [TestMethod]
	    public void superSetsOfSimpleSet() {
            HashSet<HashSet<int>> expected = new HashSet<HashSet<int>>();
		    expected.Add(setWithElements());
		    expected.Add(setWithElements(1));
		    expected.Add(setWithElements(2));
		    expected.Add(setWithElements(1, 2));
            setEquals(expected, SetUtil.superSets(setWithElements(1, 2)));
	    }

        [Ignore]
        [TestMethod]
	    public void superSetsOfBiggerSet() {
            HashSet<HashSet<int>> expected = new HashSet<HashSet<int>>();
		    expected.Add(setWithElements());
		    expected.Add(setWithElements(1));
		    expected.Add(setWithElements(2));
		    expected.Add(setWithElements(3));
		    expected.Add(setWithElements(1, 2));
		    expected.Add(setWithElements(1, 3));
		    expected.Add(setWithElements(2, 3));
		    expected.Add(setWithElements(1, 2, 3));

            setEquals(expected, SetUtil.superSets(setWithElements(1, 2, 3)));
	    }

        [Ignore]
        [TestMethod]
	    public void superSetsOfEvenBiggerSet() {
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

            setEquals(expected, SetUtil.superSets(setWithElements(1, 2, 3, 4)));
	    }
	
	    private HashSet<int> setWithElements(params int[] elements) {
		    HashSet<int> result = new HashSet<int>();
		    foreach (int integer in elements) {
			    result.Add(integer);
		    }
		    return result;
	    }

        private void setEquals(HashSet<HashSet<int>> expected, HashSet<HashSet<int>> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (HashSet<int> set in expected)
            {
                bool inSet = false;
                foreach (HashSet<int> actualSet in actual)
                {
                   if(set.SetEquals(actualSet)){
                       inSet = true;
                   }
                }
                Assert.IsTrue(inSet);
            }
        }

    }
}
