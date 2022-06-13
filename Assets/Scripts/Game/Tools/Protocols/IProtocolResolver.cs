namespace Baraboom.Game.Tools.Protocols
{
	public interface IProtocolResolver
	{
		T Resolve<T>();

		T TryResolve<T>();
	}
}