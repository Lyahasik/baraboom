using Baraboom.Game.Tools;
using UnityEngine;

namespace Baraboom.Game.Level
{
	[RequireComponent(typeof(DiscreteTransform))]
	public abstract class Block : VerboseBehaviour
	{
		#region facade

		public Vector3Int DiscretePosition => _discreteTransform.DiscretePosition;

		#endregion

		#region interior

		private DiscreteTransform _discreteTransform;

		protected virtual void Awake()
		{
			_discreteTransform = GetComponent<DiscreteTransform>();
		}

		protected virtual void Start()
		{
			GameObject.Find("Level").GetComponent<IBlockRegistry>().Register(this);
		}

		#endregion
	}
}