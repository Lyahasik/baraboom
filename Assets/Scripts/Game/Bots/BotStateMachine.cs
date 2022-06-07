using Baraboom.Game.Bots.Tools.StateMachine;
using UnityEngine;

namespace Baraboom.Game.Bots
{
	[RequireComponent(typeof(BotController))]
	public sealed class BotStateMachine : StateMachine
	{
		private BotController _controller;

		protected override IState InitialState => new States.Roaming(_controller);

		private void Awake()
		{
			_controller = GetComponent<BotController>();
		}
	}
}