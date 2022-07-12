using UnityEngine;
using Zenject;

namespace Baraboom.Game.UI
{
	[RequireComponent(typeof(Dialog))]
	public class DialogInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<Dialog>()
			         .FromInstance(GetComponent<Dialog>());
		}
	}
}