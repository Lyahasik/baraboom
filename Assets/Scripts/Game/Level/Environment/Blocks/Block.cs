using Baraboom.Core.Tools;
using Baraboom.Game.Tools.DiscreteWorld;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Level.Environment
{
	[RequireComponent(typeof(DiscreteTransform))]
	public abstract class Block : VerboseBehaviour
	{
		#region facade

		public Vector3Int DiscretePosition => _discreteTransform.DiscretePosition;

		public abstract bool IsWalkable { get; }

		#endregion

		#region interior

		[Inject] private IBlockRegistry _blockRegistry;
		private DiscreteTransform _discreteTransform;

		protected virtual void Awake()
		{
			_discreteTransform = GetComponent<DiscreteTransform>();
			_blockRegistry.Register(this);
		}

		#endregion
	}
}