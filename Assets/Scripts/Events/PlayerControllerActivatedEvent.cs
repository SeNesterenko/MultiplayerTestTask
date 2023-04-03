using Models;
using Player;
using SimpleEventBus.Events;

namespace Events
{
    public class PlayerControllerActivatedEvent : EventBase
    {
        public PlayerController PlayerController { get; }
        public PlayerModel PlayerModel { get; }

        public PlayerControllerActivatedEvent(PlayerController playerController, PlayerModel playerModel)
        {
            PlayerController = playerController;
            PlayerModel = playerModel;
        }
    }
}