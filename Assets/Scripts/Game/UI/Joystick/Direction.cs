using UnityEngine;

namespace Baraboom.Game.UI
{
	public struct Direction
	{
		public Axis Axis { get; }
		public Sign Sign { get; }

		public Direction(Axis axis, Sign sign)
		{
			Axis = axis;
			Sign = sign;
		}

		public static bool operator ==(Direction left, Direction right)
		{
			return left.Axis == right.Axis && left.Sign == right.Sign;
		}

		public static bool operator !=(Direction left, Direction right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return $"({Axis}:{Sign})";
		}
	}

	public static class DirectionTools
	{
		public static Vector2Int ToVector(this Direction direction)
		{
			var result = direction.Axis switch
			{
				Axis.X => new Vector2Int(1, 0),
				Axis.Y => new Vector2Int(0, 1)
			};

			if (direction.Sign == Sign.Minus)
				result *= -1;

			return result;
		}
	}
}