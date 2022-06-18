using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace Baraboom.Game.Tools.Algorithms.Bresenham
{
	// That's stupid to use Bresenham here (see Reverse calls), but it was fastest solution for me.
	public static class Bresenham
	{
		#region facade

		public static IEnumerable<Vector2Int> Iterate(Vector2Int start, Vector2Int finish)
		{
			return Iterate(start.x, start.y, finish.x, finish.y).Select(xy => new Vector2Int(xy.x, xy.y));
		}

		#endregion

		#region interior

		private static IEnumerable<(int x, int y)> Iterate(int x0, int y0, int x1, int y1)
		{
			if (Math.Abs(y1 - y0) < Math.Abs(x1 - x0))
			{
				if (x0 > x1)
					return IterateLow(x1, y1, x0, y0).Reverse();
				else
					return IterateLow(x0, y0, x1, y1);
			}
			else
			{
				if (y0 > y1)
					return IterateHigh(x1, y1, x0, y0).Reverse();
				else
					return IterateHigh(x0, y0, x1, y1);
			}
		}

		[SuppressMessage("ReSharper", "InconsistentNaming")]
		private static IEnumerable<(int x, int y)> IterateLow(int x0, int y0, int x1, int y1)
		{
			var dx = x1 - x0;
			var dy = y1 - y0;
			var yi = 1;

			if (dy < 0)
			{
				yi = -1;
				dy = -dy;
			}

			var D = 2 * dy - dx;
			var y = y0;

			foreach (var x in Range(x0, x1))
			{
				yield return (x, y);

				if (D > 0)
				{
					y += yi;
					D += 2 * (dy - dx);
				}
				else
				{
					D += 2 * dy;
				}
			}
		}

		[SuppressMessage("ReSharper", "InconsistentNaming")]
		private static IEnumerable<(int x, int y)> IterateHigh(int x0, int y0, int x1, int y1)
		{
			var dx = x1 - x0;
			var dy = y1 - y0;
			var xi = 1;

			if (dx < 0)
			{
				xi = -1;
				dx = -dx;
			}

			var D = 2 * dx - dy;
			var x = x0;

			foreach (var y in Range(y0, y1))
			{
				yield return (x, y);

				if (D > 0)
				{
					x += xi;
					D += 2 * (dx - dy);
				}
				else
				{
					D += 2 * dx;
				}
			}
		}

		private static IEnumerable<int> Range(int from, int to)
		{
			if (from < to)
			{
				while (from <= to)
					yield return from++;
			}
			else
			{
				while (from >= to)
					yield return from--;
			}
		}

		#endregion
	}
}