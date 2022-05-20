using System;

namespace Events
{
    public static class ManagerDataPlayer
    {
        public static Action OnIncrementDamage;
        public static Action OnIncrementRange;
        public static Action<float> OnAddSpeed;

        //TODO вызвать при смене сцены
        public static void FreeEvents()
        {
            OnIncrementDamage = null;
            OnIncrementRange = null;
            OnAddSpeed = null;
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
