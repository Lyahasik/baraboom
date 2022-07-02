using UnityEngine;
using Zenject;
using Baraboom.Game.UI;

namespace Baraboom.Game.Characters.Player.PlayerInput
{
	public class PlayerInputReceiverTouch : MonoBehaviour, IPlayerInputReceiver
	{
		#region facade

		Vector2Int IPlayerInputReceiver.Movement
		{
			get => _touchController.Drag;
		}

		bool IPlayerInputReceiver.Bomb
		{
			get => _touchController.Click;
		}

		#endregion

		#region interior

		[Inject] private TouchController _touchController;

		#endregion
	}
}