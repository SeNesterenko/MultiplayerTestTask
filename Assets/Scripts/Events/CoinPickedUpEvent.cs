using Entities;
using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class CoinPickedUpEvent : EventBase
    {
        public PlayerModel PlayerModel { get; }
        public Coin Coin { get; }

        public CoinPickedUpEvent(PlayerModel playerModel, Coin coin)
        {
            PlayerModel = playerModel;
            Coin = coin;
        }
    }
}