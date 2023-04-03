using Entities;
using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class PlayerGotDamageEvent : EventBase
    {
        public PlayerModel PlayerModel { get; }
        public Bullet Bullet { get; }

        public PlayerGotDamageEvent(PlayerModel playerModel, Bullet bullet)
        {
            PlayerModel = playerModel;
            Bullet = bullet;
        }
    }
}