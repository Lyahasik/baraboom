using System;

namespace Events
{
    public static class ManagerDataPlayer
    {
        public static Action OnIncrementMaxNumberPlantedBombs;
        public static Action OnIncrementNumberPlantedBombs;
        public static Action OnDecrementNumberPlantedBombs;
        
        public static Action OnIncrementDamage;
        public static Action OnIncrementRange;
        public static Action<float> OnAddSpeed;

        //TODO вызвать при смене сцены
        public static void FreeEvents()
        {
            OnIncrementMaxNumberPlantedBombs = null;
            OnIncrementNumberPlantedBombs = null;
            OnDecrementNumberPlantedBombs = null;
            
            OnIncrementDamage = null;
            OnIncrementRange = null;
            OnAddSpeed = null;
        }

        public static void IncrementMaxNumberPlantedBombs()
        {
            OnIncrementMaxNumberPlantedBombs?.Invoke();
        }

        public static void IncrementNumberPlantedBombs()
        {
            OnIncrementNumberPlantedBombs?.Invoke();
        }

        public static void DecrementNumberPlantedBombs()
        {
            OnDecrementNumberPlantedBombs?.Invoke();
        }

        public static void IncrementDamage()
        {
            OnIncrementDamage?.Invoke();
        }

        public static void IncrementRange()
        {
            OnIncrementRange?.Invoke();
        }

        public static void AddSpeed(float value)
        {
            OnAddSpeed?.Invoke(value);
        }
    }
}
