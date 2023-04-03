using System;
using Events;
using Models;
using Photon.Pun;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Player
{
    public class PlayerManagement : MonoBehaviour, IDisposable
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private PlayerController _playerController;
    
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 2f;

        private FixedJoystick _joystick;
        private CompositeDisposable _subscriptions;

        public void Initialize(PlayerModel playerModel, FixedJoystick joystick)
        {
            _playerController.Initialize(playerModel, _photonView);
            _joystick = joystick;
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<ShootButtonOnClickedEvent>(Shoot)
            };
        }
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }

        private void Update()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
            {
                UserInput();   
            }
        }

        private void UserInput()
        {
            if (_photonView.IsMine)
            {
                var x = _joystick.Horizontal;
                var y = _joystick.Vertical;
                Move(x, y);
            }
        }

        private void Move(float x, float y)
        {
            var moveStep = Time.deltaTime * _moveSpeed;
            var rotationStep = Time.deltaTime * _rotationSpeed;
        
            transform.Translate(Vector3.up * moveStep * y);
            transform.Rotate(new Vector3(0, 0, x) * -90 * rotationStep);
        }

        private void Shoot(ShootButtonOnClickedEvent eventData)
        {
            _playerController.Shoot();
        }
    }
}