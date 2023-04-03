using GlobalConstants;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Mangers
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _createInputField;
        [SerializeField] private TMP_InputField _joinInputField;
        [SerializeField] private TMP_InputField _playerName;

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(_createInputField.text);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(_joinInputField.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.NickName = _playerName.text;
            PhotonNetwork.LoadLevel(SceneNames.GAME_SCENE);
        }
    }
}