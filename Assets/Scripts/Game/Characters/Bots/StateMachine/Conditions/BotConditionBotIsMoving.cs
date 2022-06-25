using Baraboom.Game.Characters.Bots.Protocols;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	[UsedImplicitly]
	public class BotConditionBotIsMoving : BotCondition
	{
		[Inject] private IBotController _controller;

		public override bool Evaluate()
		{
			return _controller.IsMoving;
		}
	}
}