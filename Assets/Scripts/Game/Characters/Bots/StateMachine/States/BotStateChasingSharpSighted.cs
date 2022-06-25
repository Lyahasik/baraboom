using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.StateMachine.States
{
	[UsedImplicitly]
	public class BotStateChasingSharpSighted : BotStateChasingBase
	{
		protected override bool ShouldChasePlayer => true;
	}
}