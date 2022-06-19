using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using Baraboom.Game.Tools.Protocols;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine
{
	// TODO Inject
	public class BotStateMachineContext : MonoBehaviour, IContext
	{
		#region facade

		[Inject]
		public ILevel Level { get; private set; }

		[Inject]
		public IObservablePlayer Player { get; private set; }

		public IProtocolResolver BotProtocolResolver { get; private set; }

		#endregion

		#region interior

		private void Awake()
		{
			BotProtocolResolver = new GameObjectProtocolResolver(gameObject);
		}

		#endregion
	}
}