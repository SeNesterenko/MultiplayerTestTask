using Models;
using UI.Views;
using UnityEngine;

namespace UI.ViewControllers
{
    public class GameOverViewController : MonoBehaviour
    {
        [SerializeField] private GameOverView _gameOverView;

        public void Initialize(PlayerModel playerModel)
        {
            _gameOverView.Display(playerModel.PlayerName, playerModel.CountOfCoins.ToString());
        }
    }
}