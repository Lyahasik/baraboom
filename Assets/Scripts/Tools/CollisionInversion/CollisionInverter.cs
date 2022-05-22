using UnityEngine;

namespace Tools.CollisionInversion
{
	/// <summary>
	/// Если происходит столкновение коллайдра и триггера, только колладер получает оповещение о столкновении.
	/// Уведомляет триггер о столкновение. 
	/// </summary>
	public class CollisionInverter : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			var invertedTrigger = other.GetComponent<IInvertedTrigger>();
			if (invertedTrigger != null)
				invertedTrigger.OnInvertedCollision(gameObject);
		}
	}
}