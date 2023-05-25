using UnityEngine;

namespace TankBattle.Singleton
{
    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private TankView tank;

        private void Start()
        {
            
        }
    }
}
