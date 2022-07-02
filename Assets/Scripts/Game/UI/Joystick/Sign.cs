namespace Baraboom.Game.UI
{
	public enum Sign
	{
		Plus,
		Minus
	}

	public static class SignTools
	{
		public static Sign DetermineSign(float value)
		{
			return value > 0 ? Sign.Plus : Sign.Minus;
		}
	}
}