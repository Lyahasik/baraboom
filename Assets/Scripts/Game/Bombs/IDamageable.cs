using Baraboom.Game.Tools;

namespace Baraboom.Game.Bombs
{
    public interface IDamageable : IMonoBehaviour
    {
        void TakeDamage(int damage);
    }
}