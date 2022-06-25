using System.Collections.Generic;
using Baraboom.Game.Characters.Bots.Tools.Navigation;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Protocols
{
	public interface IBotController
	{
		Vector3Int Position { get; }

		bool IsMoving { get; }

		Path Path { set; }

		void RequestStop();
	}
}