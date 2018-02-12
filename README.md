# supersetkata
A C# TDD code kata

## Pre-requisites

- Git
- Visual Studio 2015 or better

## Install

Go into the folder where you wish to clone your solution and type the following on the command line (or in [git bash](https://git-scm.com/download/win))

```Batch
git clone https://github.com/ToJans/supersetkata.git
```

## Usage

The idea is to implement a solution for a problem based on the tests:

- Open the solution you cloned during installation in Visual Studio
- You start out with all tests disabled. Build the solution. Everything should work
- Remove the `ignore` attribute on the first test
   ```C#
    public class SuperSetsTest
    {
        [Ignore] // <-- This one
        [TestMethod]
        public void superSetsOfEmptySet() {
		    setEquals(new HashSet<HashSet<int>>(), SetUtil.superSets(new HashSet<int>()));
	    }
   ```
- Run the test, watch it fail 
- Implement the minimum functionality required to get the first test working
- Repeat ad libitum

## Example implementation

If you are stuck, you can check an example implementation [here](https://github.com/ToJans/supersetkata/tree/example).
