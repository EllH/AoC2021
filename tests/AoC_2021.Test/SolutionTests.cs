using System;
using System.Threading.Tasks;
using AoCHelper;
using NUnit.Framework;

namespace AoC_2021.Test
{
    public static class SolutionTests
    {
        public class Solutions
        {
            [TestCase(typeof(Day01), "1583", "1627")]
            [TestCase(typeof(Day02), "2039912", "1942068080")]
            [TestCase(typeof(Day03), "3958484", "1613181")]
            [TestCase(typeof(Day04), "87456", "15561")]
            [TestCase(typeof(Day05), "6548", "19663")]
            public async Task Test(Type type, string sol1, string sol2)
            {
                if (Activator.CreateInstance(type) is BaseDay instance)
                {
                    Assert.AreEqual(sol1, await instance.Solve_1());
                    Assert.AreEqual(sol2, await instance.Solve_2());
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}
