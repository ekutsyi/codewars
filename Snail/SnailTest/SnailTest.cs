using System.Linq;

namespace SnailTest
{
    public class SnailTests
    {
        [Test]
        public void SnailTest1()
        {
            int[,] array = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            Test(array, r);
        }

        [Test]
        public void SnailTest2()
        {
            int[,] array = {
                {1, 2, 3, 4, 5},
                {4, 5, 6, 7, 8},
                {7, 8, 9, 10, 11}
            };
            var r = new[] { 1, 2, 3, 4, 5, 8, 11, 10, 9, 8, 7, 4, 5, 6, 7};
            Test(array, r);
        }

        [Test]
        public void SnailTest3()
        {
            int[,] array = { { } };
            var r = Array.Empty<int>();
            Test(array, r);
        }

        [Test]
        public void SnailTest4()
        {
            int[,] array = { {1} };
            var r = new int[] {1};
            Test(array, r);
        }

        public void Test(int[,] array, int[] result)
        {
            Assert.AreEqual(result, SnailLibrary.Snail.doJob(array));
        }
    }
}