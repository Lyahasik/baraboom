using UnityEngine;

namespace Baraboom.Tests.Tools.Algorithms.AStar
{
	public class Point : Game.Tools.Algorithms.AStar.INode
	{
		public Point(string name, float x, float y)
		{
			Name = name;
			Position = new Vector2(x, y);
		}
		
		public string Name { get; }

		public Vector2 Position { get; }

		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(object that)
		{
			if (that is not Point thatPoint)
				return false;

			return this.Position == thatPoint.Position;
		}

		public override int GetHashCode()
		{
			return Position.GetHashCode();
		}
	}
}