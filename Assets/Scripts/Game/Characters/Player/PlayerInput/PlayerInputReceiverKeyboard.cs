using UnityEngine;

namespace Baraboom.Game.Characters.Player.PlayerInput
{
	public class PlayerInputReceiverKeyboard : MonoBehaviour, IPlayerInputReceiver
	{
		#region facade

		Vector2Int IPlayerInputReceiver.Movement
		{
			get
			{
				if (Input.GetKey(KeyCode.A))
					return new Vector2Int(-1, 0);
				if (Input.GetKey(KeyCode.D))
					return new Vector2Int(+1, 0);
				if (Input.GetKey(KeyCode.W))
					return new Vector2Int(0, +1);
				if (Input.GetKey(KeyCode.S))
					return new Vector2Int(0, -1);

				return Vector2Int.zero;
			}
		}

		bool IPlayerInputReceiver.Bomb
		{
			get => Input.GetKey(KeyCode.Space);
		}

		#endregion
	}
}