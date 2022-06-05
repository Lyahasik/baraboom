using System.Collections.Generic;
using System.Linq;

namespace Baraboom.Game.Tools.Algorithms.AStar
{
	public class NodeWrapper<TNode> where TNode : INode
	{
		#region facade

		public NodeWrapper(IGraph<TNode> graph, TNode target, HeuristicDelegate<TNode> heuristic)
		{
			_graph = graph;
			_target = target;
			_heuristic = heuristic;
		}

		public NodeWrap<TNode> Wrap(TNode node, NodeWrap<TNode> parentWrap = null)
		{
			return new NodeWrap<TNode>(node, parentWrap, ComputeHeuristic(node));
		}

		public IEnumerable<NodeWrap<TNode>> WrapNeighbors(NodeWrap<TNode> nodeWrap)
		{
			return _graph.GetNeighbors(nodeWrap.Node).Select(node => new NodeWrap<TNode>(node, nodeWrap, ComputeHeuristic(node)));
		}

		#endregion

		#region interior

		private readonly IGraph<TNode> _graph;
		private readonly TNode _target;
		private readonly HeuristicDelegate<TNode> _heuristic;

		private float ComputeHeuristic(TNode current)
		{
			return _heuristic(current, _target);
		}

		#endregion
	}
}