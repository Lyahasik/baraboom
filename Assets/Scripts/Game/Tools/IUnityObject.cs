namespace Baraboom.Game.Tools
{
	public interface IUnityObject
	{
		public sealed bool IsNull()
		{
			return (UnityEngine.Object)this == null;
		}

		public sealed bool IsNotNull()
		{
			return (UnityEngine.Object)this != null;
		}
	}
}