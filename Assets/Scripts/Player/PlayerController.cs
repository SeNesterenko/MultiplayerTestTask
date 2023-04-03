using Entities;
using Events;
using GlobalConstants;
using Models;
using Photon.Pun;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerController : MonoBehaviour, IPunObservable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Weapon _weapon;

        private PhotonView _photonView;
        private PlayerModel _playerModel;

        public void Initialize(PlayerModel playerModel, PhotonView photonView)
        {
            _playerModel = playerModel;
            _photonView = photonView;

            if (_photonView.IsMine)
            {
                _spriteRenderer.color = _playerModel.Color;
                EventStreams.Game.Publish(new PlayerControllerActivatedEvent(this, playerModel));
            }
        }
        
        public void Shoot()
        {
            _weapon.Shoot();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_playerModel);
            }
            else
            {
                _playerModel = (PlayerModel) stream.ReceiveNext();
                _spriteRenderer.color = _playerModel.Color;
            }
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (otherCollider.gameObject.CompareTag(Tags.COIN))
            {
                var coin = otherCollider.GetComponent<Coin>();
                EventStreams.Game.Publish(new CoinPickedUpEvent(_playerModel, coin));
            }
            
            if (otherCollider.gameObject.CompareTag(Tags.BULLET))
            {
                var bullet = otherCollider.GetComponent<Bullet>();
                EventStreams.Game.Publish(new PlayerGotDamageEvent(_playerModel, bullet));
                
                CheckIsDead();
            }
        }
        
        private void CheckIsDead()
        {
            if (_playerModel.Health <= 0)
            {
                EventStreams.Game.Publish(new GameOverEvent(this));
            }
        }
    }
}