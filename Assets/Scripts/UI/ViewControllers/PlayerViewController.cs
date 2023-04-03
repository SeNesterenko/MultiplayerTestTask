using Models;
using UI.Views;
using UnityEngine;

namespace UI.ViewControllers
{
    public class PlayerViewController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
    
        private PlayerModel _playerModel;

        public void Initialize(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerView.Initialize(_playerModel.Health, _playerModel.CountOfCoins);
        }

        private void Update()
        {
            _playerView.Display(_playerModel.Health, _playerModel.CountOfCoins);
        }
    }
}