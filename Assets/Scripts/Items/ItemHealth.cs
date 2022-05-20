using Events;

namespace Items
{
    public class ItemHealth : BaseItem, IActivated
    {
        private const int ADDED_HEALTH = 1;
        
        public void Activate()
        {
            ManagerDataPlayer.AddHealth(ADDED_HEALTH);
            DestructItem();
        }
    }
}
