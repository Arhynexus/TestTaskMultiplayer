using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTaskMultiPlayer
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        private Tank m_Player;


        private void Start()
        {
            m_Player = GamePlayer.Instance.Tank;
        }

        private void Update()
        {

        }

        public void Leave()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void DestroyPlayer()
        {
            Destroy(m_Player.gameObject);
        }

        public override void OnLeftRoom()
        {
            DestroyPlayer();
            SceneManager.LoadScene(0);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            print("Player intered room" + newPlayer.NickName);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            print("Player has left room" + otherPlayer.NickName);
        }
    }
}