using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTaskMultiPlayer
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Tank m_PlayerPrefab;
        [SerializeField] private float StartSpawnPositionMinX, StartSpawnPositionMinY, StartSpawnPositionMaxX, StartSpawnPositionMaxY;
        [SerializeField] private PointerClickHold m_WeaponButton;
        [SerializeField] private UpdateMoneyUI m_MoneyUI;
        private List<Player> m_Players; 

        private void Start()
        {
            Vector2 startPosition = new Vector2(Random.Range(StartSpawnPositionMinX, StartSpawnPositionMaxX), Random.Range(StartSpawnPositionMinY, StartSpawnPositionMaxY));
            var m_PlayerTank = PhotonNetwork.Instantiate(m_PlayerPrefab.name, startPosition, Quaternion.identity).GetComponent<Tank>();
            m_MoneyUI.SetBag(m_PlayerTank.GetComponent<Bag>());
        }

        public void Leave()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            print("Player intered room" + newPlayer.NickName);
            if (m_Players == null)
            {
                m_Players = new List<Player>();
            }
            m_Players.Add(newPlayer);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            print("Player has left room" + otherPlayer.NickName);
        }

    }
}