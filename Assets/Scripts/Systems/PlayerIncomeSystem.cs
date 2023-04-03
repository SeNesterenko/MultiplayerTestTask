using System;
using Events;
using SimpleEventBus.Disposables;

namespace Systems
{
    public class PlayerIncomeSystem : IDisposable
    {
        private readonly CompositeDisposable _subscriptions;

        public PlayerIncomeSystem()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<CoinPickedUpEvent>(IncreasePlayerIncome)
            };
        }
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }

        private void IncreasePlayerIncome(CoinPickedUpEvent eventData)
        {
            eventData.PlayerModel.CountOfCoins += eventData.Coin.GetValue();
            eventData.Coin.gameObject.SetActive(false);
        }
    }
}