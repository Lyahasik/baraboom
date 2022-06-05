using Baraboom.Game.Tools.Algorithms.AStar;
using NUnit.Framework;
using UnityEngine;

namespace Baraboom.Tests.Tools.Algorithms.AStar
{
	public static class TestSolver
	{
		[Test]
		public static void TwoFollowingNodes_Solved()
		{
			var a = new Point("a", 0, 0);
			var b = new Point("b", 1, 0);

			var map = new Map();
			map.Link(a, b);
		
			CollectionAssert.AreEquivalent(
				new[] { a, b },
				Solver.Solve(map, a, b, EuclideanHeuristic)
			);
		}
		
		[Test]
		public static void TwoUnconnectedNode_Exception()
		{
			var a = new Point("a", 0, 0);
			var b = new Point("b", 1, 0);

			var map = new Map();

			Assert.Throws<PathNotFoundException>(() => Solver.Solve(map, a, b, EuclideanHeuristic));
		}

		[Test]
		public static void ThreeFollowingNodes_Solved()
		{
			var a = new Point("a", 0, 0);
			var b = new Point("b", 1, 0);
			var c = new Point("c", 2, 0);

			var map = new Map();
			map.LinkSequence(a, b, c);
		
			CollectionAssert.AreEquivalent(
				new[] { a, b, c },
				Solver.Solve(map, a, c, EuclideanHeuristic)
			);
		}
		
		[Test]
		public static void FewStepsPathAndManyStepsPath_SolvedWithFewStepsPath()
		{
			// a - b - c - d
			//	\         /
			//   * - e - *  
			
			var a = new Point("a", 0, 0);
			var b = new Point("b", 0, 1);
			var c = new Point("c", 0, 2);
			var d = new Point("d", 0, 3);
			var e = new Point("e", 0, 1);

			var map = new Map();
			map.LinkSequence(a, b, c, d);
			map.LinkSequence(a, e, d);
		
			CollectionAssert.AreEquivalent(
				new[] { a, e, d },
				Solver.Solve(map, a, d, EuclideanHeuristic)
			);
		}

		[Test]
		public static void LongPathAndShortPath_SolvedWithShortPath()
		{
			// a - b - c - d
			//	\\       //
			//    e --- f 
			
			var a = new Point("a", 0, 0);
			var b = new Point("b", 1, 0);
			var c = new Point("c", 2, 0);
			var d = new Point("d", 3, 0);
			var e = new Point("e", 1, 10);
			var f = new Point("f", 2, 10);

			var map = new Map();
			map.LinkSequence(a, b, c, d);
			map.LinkSequence(a, e, f, d);

			CollectionAssert.AreEquivalent(
				new[] { a, b, c, d },
				Solver.Solve(map, a, d, EuclideanHeuristic)
			);
		}

		[Test]
		public static void LongFewStepsPathAndShortManyStepsPath_SolvedShortManyStepsWithPath()
		{
			// a - b - c -- d
			// \\         //
			//  ** - e - ** 

			var a = new Point("a", 0, 0);
			var b = new Point("b", 1, 0);
			var c = new Point("c", 2, 0);
			var d = new Point("d", 3, 0);
			var e = new Point("e", 1, 10);

			var map = new Map();
			map.LinkSequence(a, b, c, d);
			map.LinkSequence(a, e, d);

			CollectionAssert.AreEquivalent(
				new[] { a, b, c, d },
				Solver.Solve(map, a, d, EuclideanHeuristic)
			);
		}

		private static float EuclideanHeuristic(Point a, Point b)
		{
			return Vector2.Distance(a.Position, b.Position);
		}
	}
}