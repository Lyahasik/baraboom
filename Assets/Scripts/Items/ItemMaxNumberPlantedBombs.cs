using Events;

namespace Items
{
    public class ItemMaxNumberPlantedBombs : BaseItem, IActivated
    {
        public void Activate()
        {
            ManagerDataPlayer.IncrementMaxNumberPlantedBombs();
            DestructItem();
        }
    }
}
