using System.Collections.Generic;
using System.Linq;
using Enumerable = Baraboom.Game.Tools.Extensions.Enumerable;

namespace Baraboom.Game.Tools.Algorithms.AStar
{
	public sealed class NodeWrap<TNode> where TNode : INode
	{
		#region facade

		public NodeWrap(TNode node, NodeWrap<TNode> parent, float h)
		{
			_node = node;
			_parent = parent;
			_g = parent != null ? parent.G + 1 : 0;
			_h = h;
		}

		public TNode Node => _node;

		public int G => _g; 

		public float H => _h; 

		public float F => G + H;

		public IEnumerable<TNode> Path
		{
			get => Enumerable.Flatten(this, node => node._parent).Reverse().Select(wrap => wrap._node);
		}

		public override string ToString()
		{
			return _node.ToString();
		}

		public override bool Equals(object @object)
		{
			if (@object is TNode node)
				return _node.Equals(node);
			if (@object is NodeWrap<TNode> nodeWrap)
				return this._node.Equals(nodeWrap._node);

			return false;
		}

		public override int GetHashCode()
		{
			return _node.GetHashCode();
		}

		#endregion

		#region interior

		private readonly TNode _node;
		private readonly NodeWrap<TNode> _parent;
		private readonly int _g;
		private readonly float _h;

		#endregion
	}
}