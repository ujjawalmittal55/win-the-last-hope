using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

namespace Menus
{

    public class MainMenu : MonoBehaviourPunCallbacks
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject findOppenentPanel = null;
        [SerializeField] private TextMeshProUGUI waitingStatusText = null;
        [SerializeField] private GameObject waitingStatusPanel = null;
        private bool isConnecting = false;
        private const string GameVersion = "0.1";
        private const int MaxPlayerPerRoom = 2;
        private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;

        public void FindOpponent()
        {
            isConnecting = true;
            findOppenentPanel.SetActive(false);
            waitingStatusPanel.SetActive(true);
            waitingStatusText.text = "Searching....";

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = GameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connect To Master");
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            waitingStatusPanel.SetActive(false);
            findOppenentPanel.SetActive(true);
            Debug.Log($"Disconnected due to{cause}");
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("NO client are waiting for a oppenent ,creating a new room");
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayerPerRoom });
        }
        public override void OnJoinedRoom()
        {
            Debug.Log(":client successfully Join the room");
            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            if (playerCount != MaxPlayerPerRoom)
            {
                waitingStatusText.text = "Waiting for oppenent";
                Debug.Log("Client is waiting for oppenent");
            }
            else
            {
                waitingStatusText.text = "opponent found";
                Debug.Log("Match is ready to begin");
            }

        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            PhotonNetwork.LoadLevel("Level1");
        }
    }
}
