using Baraboom.Game.Characters.Bots.Tools.Navigation;

namespace Baraboom.Game.Characters.Bots.Protocols
{
	public interface IBotPathValidator
	{
		bool IsValid(Path path);
	}
}