using Events;
using Models;
using UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ViewControllers
{
    public class PlayerViewController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Button _shootButton;
    
        private PlayerModel _playerModel;

        public void Initialize(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerView.Initialize(_playerModel.Health, _playerModel.CountOfCoins);
            _shootButton.onClick.AddListener(ShootButtonOnClicked);
        }

        private void Update()
        {
            _playerView.Display(_playerModel.Health, _playerModel.CountOfCoins);
        }

        private void ShootButtonOnClicked()
        {
            EventStreams.Game.Publish(new ShootButtonOnClickedEvent());
        }
    }
}