using Events;
using UnityEngine;

namespace Items
{
    public class ItemSpeed : BaseItem, IActivated
    {
        [SerializeField] private float _addedSpeed = 0.2f;
        public void Activate()
        {
            ManagerDataPlayer.AddSpeed(_addedSpeed);
            DestructItem();
        }
    }
}
