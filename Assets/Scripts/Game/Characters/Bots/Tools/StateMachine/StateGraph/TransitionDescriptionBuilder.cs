namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public class TransitionDescriptionBuilder
	{
		#region facade

		public TransitionDescription Description => _description;

		public TransitionDescriptionBuilder From<T>() where T : IState
		{
			_description.OriginState = typeof(T);
			return this;
		}

		public TransitionDescriptionBuilder To<T>() where T : IState
		{
			_description.DestinationState = typeof(T);
			return this;
		}

		public TransitionDescriptionBuilder If(TransitionCondition condition)
		{
			_description.Condition = condition;
			return this;
		}

		#endregion

		#region interior

		private readonly TransitionDescription _description = new();

		#endregion
	}
}