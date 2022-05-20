using Events;

namespace Items
{
    public class ItemRange : BaseItem, IActivated
    {
        public void Activate()
        {
            ManagerDataPlayer.IncrementRange();
            DestructItem();
        }
    }
}
