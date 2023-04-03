using Models;
using Photon.Pun;
using Player;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems
{
    public class PlayerSpawnerSystem : MonoBehaviour
    {
        [SerializeField] private int _spawnRadius = 5;
        [SerializeField] private PlayerManagement _playerPrefab;

        public void SpawnPlayer(PlayerModel playerModel, FixedJoystick joystick)
        {
            var randomPosition = Random.insideUnitCircle * _spawnRadius;
            var playerManagement = PhotonNetwork.Instantiate(_playerPrefab.gameObject.name, randomPosition, quaternion.identity);
            playerManagement.gameObject.GetComponent<PlayerManagement>().Initialize(playerModel, joystick);
        }
    }
}