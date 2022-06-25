namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public class TransitionCondition
	{
		#region facade

		public static TransitionCondition ForType<T>() where T : ICondition
		{
			return new TransitionCondition(evaluator => evaluator.Evaluate(typeof(T)), typeof(T).Name);
		}

		public static TransitionCondition operator !(TransitionCondition original)
		{
			return new TransitionCondition(
				evaluator => !original.Evaluate(evaluator),
				$"!{original}"
			);
		}

		public static TransitionCondition operator &(TransitionCondition left, TransitionCondition right)
		{
			return new TransitionCondition(
				evaluator => left.Evaluate(evaluator) && right.Evaluate(evaluator),
				$"{left} & {right}"
			);
		}

		public static TransitionCondition operator |(TransitionCondition left, TransitionCondition right)
		{
			return new TransitionCondition(
				evaluator => left.Evaluate(evaluator) || right.Evaluate(evaluator),
				$"{left} | {right}"
			);
		}

		public bool Evaluate(ITransitionConditionEvaluator evaluator)
		{
			return _expression(evaluator);
		}

		public override string ToString()
		{
			return _description;
		}

		#endregion

		#region interior

		private delegate bool ExpressionDelegate(ITransitionConditionEvaluator evaluator);

		private readonly ExpressionDelegate _expression;
		private readonly string _description;

		private TransitionCondition(ExpressionDelegate expression, string description)
		{
			_expression = expression;
			_description = description;
		}

		#endregion
	}
}