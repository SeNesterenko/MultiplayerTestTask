using Entities;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems
{
    public class CoinSpawnerSystem : MonoBehaviour
    {
        [SerializeField] private int _countCoins = 10;
        [SerializeField] private int _spawnRadius = 5;
        
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private PhotonView _photonView;

        public void Spawn()
        {
            if (_photonView.AmOwner)
            {
                for (var i = 0; i < _countCoins; i++)
                {
                    var randomPosition = Random.insideUnitCircle * _spawnRadius;
                    PhotonNetwork.Instantiate(_coinPrefab.gameObject.name, randomPosition, quaternion.identity);
                }
            }
        }
    }
}