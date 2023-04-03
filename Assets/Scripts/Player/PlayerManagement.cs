using Models;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerManagement : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private PlayerController _playerController;
    
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 2f;

        private FixedJoystick _joystick;

        public void Initialize(PlayerModel playerModel, FixedJoystick joystick)
        {
            _playerController.Initialize(playerModel, _photonView);
            _joystick = joystick;
        }

        private void Update()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount >= 1)
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

                if (Input.touchCount > 0)
                {
                    _playerController.Shoot();
                }
            }
        }

        private void Move(float x, float y)
        {
            var moveStep = Time.deltaTime * _moveSpeed;
            var rotationStep = Time.deltaTime * _rotationSpeed;
        
            transform.Translate(Vector3.up * moveStep * y);
            transform.Rotate(new Vector3(0, 0, x) * -90 * rotationStep);
        }
    }
}