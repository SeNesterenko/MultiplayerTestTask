using SimpleEventBus.Events;
using Weapons;

namespace Events
{
    public class WeaponSpawnedEvent : EventBase
    {
        public Weapon Weapon { get; }

        public WeaponSpawnedEvent(Weapon weapon)
        {
            Weapon = weapon;
        }
    }
}