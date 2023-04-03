using Models;
using Photon.Pun;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    public class PlayerModelCreatorSystem : MonoBehaviour
    {
        [SerializeField] private PlayersConfig _playersConfig;

        public PlayerModel Create()
        {
            var randomIndex = Random.Range(0, _playersConfig.PlayerModels.Length);

            var health = _playersConfig.PlayerModels[randomIndex].Health;
            var color = _playersConfig.PlayerModels[randomIndex].Color;
            var coins = _playersConfig.PlayerModels[randomIndex].CountOfCoins;

            var model = new PlayerModel(color, health, coins, PhotonNetwork.NickName);

            return model;
        }
    }
}