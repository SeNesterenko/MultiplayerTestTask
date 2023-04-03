using System;
using Events;
using SimpleEventBus.Disposables;

namespace Systems
{
    public class PlayerDamageSystem : IDisposable
    {
        private readonly CompositeDisposable _subscriptions;

        public PlayerDamageSystem()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<PlayerGotDamageEvent>(ReducePlayerHealth)
            };
        }
        public void Dispose()
        {
            _subscriptions.Dispose();
        }

        private void ReducePlayerHealth(PlayerGotDamageEvent eventData)
        {
            eventData.PlayerModel.Health -= eventData.Bullet.GetDamageValue();
            eventData.Bullet.gameObject.SetActive(false);
        }
    }
}