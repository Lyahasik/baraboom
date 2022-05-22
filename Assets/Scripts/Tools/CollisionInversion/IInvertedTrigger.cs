using UnityEngine;

namespace Tools.CollisionInversion
{
	/// <summary>
	/// Если происходит столкновение коллайдра и триггера, только колладер получает оповещение о столкновении.
	/// Позволяет триггеру получать оповещение о столкновении. 
	/// </summary>
	public interface IInvertedTrigger : IMonoBehaviour
	{
		public void OnInvertedCollision(GameObject target);
	}
}