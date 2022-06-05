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

		public bool Equals(TNode that)
		{
			return _node.Equals(that);
		}

		public bool Equals(NodeWrap<TNode> that)
		{
			return this._node.Equals(that._node);
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