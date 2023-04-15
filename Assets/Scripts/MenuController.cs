using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MenuController : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField m_CreateLobbyField;
    [SerializeField] private InputField m_JoinLobbyField;


    private void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);
        Debug.Log("Player is set to " + PhotonNetwork.NickName);
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(m_CreateLobbyField.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(m_JoinLobbyField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
