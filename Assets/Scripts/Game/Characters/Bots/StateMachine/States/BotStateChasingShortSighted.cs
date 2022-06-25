using Baraboom.Game.Characters.Bots.Protocols;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine.States
{
	[UsedImplicitly]
	public class BotStateChasingShortSighted : BotStateChasingBase
	{
		[Inject] private IBotPlayerObserver _playerObserver;

		protected override bool ShouldChasePlayer => _playerObserver.IsPlayerVisible;
	}
}