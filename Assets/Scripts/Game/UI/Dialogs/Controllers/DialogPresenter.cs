using UnityEngine;
using Zenject;

namespace Baraboom.Game.UI
{
	public abstract class DialogController : MonoBehaviour
	{
		[Inject] protected Dialog _dialog;
	}
}