using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using Baraboom.Game.Tools.Protocols;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.StateMachine
{
	public class BotStateMachineContext : MonoBehaviour, IContext
	{
		#region facade

		public ILevel Level { get; private set; }

		public IObservablePlayer Player { get; private set; }

		public IProtocolResolver BotProtocolResolver { get; private set; }

		#endregion

		#region interior

		private void Awake()
		{
			Level = GameObject.Find("Level").GetComponent<ILevel>(); // TODO Inject
			Player = GameObject.Find("Player").GetComponent<IObservablePlayer>(); // TODO Inject
			BotProtocolResolver = new GameObjectProtocolResolver(gameObject);
		}

		#endregion
	}
}