using ExitGames.Client.Photon;
using Models;
using Photon.Pun;
using Systems;
using UI.ViewControllers;
using UnityEngine;

namespace Mangers
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private PlayerSpawnerSystem _playerSpawnerSystem;
        [SerializeField] private PlayerModelCreatorSystem _playerModelCreatorSystem;
        [SerializeField] private CoinSpawnerSystem _coinSpawnerSystem;
        [SerializeField] private PlayerViewController _playerViewController;
        [SerializeField] private FixedJoystick _fixedJoystick;

        private PlayerIncomeSystem _playerIncomeSystem;
        private PlayerDamageSystem _playerDamageSystem;
        
        private void Start()
        {
            PhotonPeer.RegisterType(typeof(PlayerModel), 12, PhotonSerializationSystem.SerializePlayerModel, PhotonSerializationSystem.DeserializePlayerModel);

            var playerModel = _playerModelCreatorSystem.Create();
            _playerSpawnerSystem.SpawnPlayer(playerModel, _fixedJoystick);
            _playerViewController.Initialize(playerModel);
            
            _coinSpawnerSystem.Spawn();

            _playerIncomeSystem = new PlayerIncomeSystem();
            _playerDamageSystem = new PlayerDamageSystem();
        }

        private void OnDestroy()
        {
            _playerIncomeSystem.Dispose();
            _playerDamageSystem.Dispose();
        }
    }
}