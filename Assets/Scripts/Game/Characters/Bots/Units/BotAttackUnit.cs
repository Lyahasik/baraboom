using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Tools;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Units
{
	public class BotAttackUnit : Killer<IBotTarget>
	{
		[SerializeField] private new int _damage;
		[SerializeField] private new float _ignoreTargetDuration;

		private void Awake()
		{
			base._damage  = this._damage;
			base._ignoreTargetDuration = this._ignoreTargetDuration;
		}
	}
}