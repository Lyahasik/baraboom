using System.Collections.Generic;
using System.Linq;
using Baraboom.Game.Tools.Algorithms.AStar;

namespace Baraboom.Tests.Tools.Algorithms.AStar
{
	public class Map : IGraph<Point>
	{
		#region facade

		public IEnumerable<Point> GetNeighbors(Point node)
		{
			if (_links.TryGetValue(node, out var links))
				return links;

			return Enumerable.Empty<Point>();
		}

		public void Link(Point a, Point b)
		{
			LinkOneWay(a, b);
			LinkOneWay(b, a);
		}

		public void LinkSequence(params Point[] sequence)
		{
			for (var i = 0; i < sequence.Length - 1; i++)
				Link(sequence[i], sequence[i + 1]);
		}

		#endregion
	
		#region interior

		private readonly Dictionary<Point, HashSet<Point>> _links = new();
	
		void LinkOneWay(Point a, Point b)
		{
			if (!_links.ContainsKey(a))
				_links[a] = new HashSet<Point>();

			_links[a].Add(b);
		}

		#endregion
	}
}