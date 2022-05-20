using Events;

namespace Items
{
    public class ItemDamage : BaseItem, IActivated
    {
        public void Activate()
        {
            ManagerDataPlayer.IncrementDamage();
            DestructItem();
        }
    }
}
