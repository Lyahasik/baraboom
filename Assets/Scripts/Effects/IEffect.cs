using System.Collections;
using Baraboom;

namespace Baraboom.Effects
{
	public interface IEffect
	{
		public IEnumerator Apply(IPlayer player);
	}
}