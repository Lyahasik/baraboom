using System.Collections.Generic;

namespace Baraboom.Game.Tools.Algorithms.AStar
{
	public interface IGraph<TNode> where TNode : INode 
	{
		public IEnumerable<TNode> GetNeighbors(TNode node);
	}
}