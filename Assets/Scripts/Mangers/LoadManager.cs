using GlobalConstants;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Mangers
{
    public class LoadManager : MonoBehaviourPunCallbacks
    {
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            SceneManager.LoadScene(SceneNames.LOBBY_SCENE);
        }
    
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }
    }
}