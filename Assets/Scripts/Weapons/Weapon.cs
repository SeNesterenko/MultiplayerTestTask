using Events;
using Systems;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        protected PoolSystem _poolSystem;
        
        public void Initialize(PoolSystem poolSystem)
        {
            _poolSystem = poolSystem;
        }
        
        public virtual void Shoot(){ }
        
        private void Start()
        {
            EventStreams.Game.Publish(new WeaponSpawnedEvent(this));
        }
    }
}