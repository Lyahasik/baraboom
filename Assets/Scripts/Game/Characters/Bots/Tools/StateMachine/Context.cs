using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public abstract class Context : ScriptableObject
	{
		public abstract void Initialize(GameObject @object);
	}
}