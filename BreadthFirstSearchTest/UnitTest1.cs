using NUnit.Framework;
using System.Collections.Generic;

namespace BreadthFirstSearchTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SearchReturnsDefaultNumberIfEmptyParams()
        {
            int[,] matrix = new int[3, 3];
            int result = BreadthFirstSearch.BFS.search(matrix);

            Assert.AreEqual(result, -1);
        }

        [Test]
        public void SearchReturnsShortestPath()
        {
            int[,] matrix = new int[3, 3] { { 1, 1, 0 },{ 1, 0, 0 },{ 1, 9, 1 } };
            
            int result = BreadthFirstSearch.BFS.search(matrix);

            Assert.AreEqual(3, result);
        }
        [Test]
        public void SearchReturns0IfObjectIsInStartingPostition()
        {
            int[,] matrix = new int[3, 3] { { 9, 1, 0 }, { 1, 0, 0 }, { 1, 0, 1 } };

            int result = BreadthFirstSearch.BFS.search(matrix);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void SearchReturnsDefaultIfCantReachObstacle()
        {
            int[,] matrix = new int[3, 3] { { 1, 1, 0 }, { 0, 0, 0 }, { 1, 0, 1 } };

            int result = BreadthFirstSearch.BFS.search(matrix);

            Assert.AreEqual(-1, result);
        }
    }
}