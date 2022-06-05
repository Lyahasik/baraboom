using System;
using System.Collections.Generic;
using Baraboom.Game.Tools.Collections;

namespace Baraboom.Game.Tools.Algorithms.AStar
{
	public delegate float HeuristicDelegate<TNode>(TNode current, TNode target) where TNode : INode;
	
	public class PathNotFoundException : Exception
	{}

	public static class Solver
	{
		public static IEnumerable<TNode> Solve<TNode>(IGraph<TNode> graph, TNode start, TNode target, HeuristicDelegate<TNode> heuristic) where TNode : INode
		{
			var wrapper = new NodeWrapper<TNode>(graph, target, heuristic);

			var open = new PriorityQueue<NodeWrap<TNode>>();
			var closed = new HashSet<NodeWrap<TNode>>();

			var startWrap = wrapper.Wrap(start);
			open.Enqueue(startWrap, startWrap.F);

			while (open.Count > 0)
			{
				var current = open.Dequeue();
				closed.Add(current);

				if (current.Equals(target))
					return current.Path;

				foreach (var neighbor in wrapper.WrapNeighbors(current))
				{
					if (closed.Contains(neighbor))
						continue;

					if (open.Find(neighbor, out var neighborVariant) && neighborVariant.F > neighbor.F)
						open.Remove(neighborVariant);
					
					open.Enqueue(neighbor, neighbor.F);
				}
			}

			throw new PathNotFoundException();
		}
	}
}