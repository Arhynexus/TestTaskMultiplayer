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
        [SerializeField] private CoinSpawner m_CoinSpawner;
        private bool m_IsLeaving = false;
        private MovementController m_MovementController;
        private List<Tank> m_Tanks = new List<Tank>();
        public List<Tank> Tanks => m_Tanks;
        public PhotonView m_GameControllerView;
        private Tank m_PlayerTank;

        [PunRPC]
        private void Start()
        {
            m_GameControllerView = GetComponent<PhotonView>();
            Vector2 startPosition = new Vector2(Random.Range(StartSpawnPositionMinX, StartSpawnPositionMaxX), Random.Range(StartSpawnPositionMinY, StartSpawnPositionMaxY));
            m_PlayerTank = PhotonNetwork.Instantiate(m_PlayerPrefab.name, startPosition, Quaternion.identity).GetComponent<Tank>();
            m_MoneyUI.SetBag(m_PlayerTank.GetComponent<Bag>());
            m_MovementController = m_PlayerTank.GetComponent<MovementController>();
        }

        [PunRPC]
        public void ShowNickNames()
        {
            foreach (var player in PhotonNetwork.PlayerList)
            {
                player.NickName = PhotonNetwork.NickName;
            }
        }

        public void Leave()
        {
            m_IsLeaving = true;
            Time.timeScale = 1;
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public void AddTankToList(Tank tank)
        {
            m_Tanks.Add(tank);
            print(PhotonNetwork.PlayerList.Length);
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            print("Player intered room" + newPlayer.NickName);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            print("Player has left room" + otherPlayer.NickName);
        }

        private void Update()
        {
            print(m_Tanks.Count);
            if (PhotonNetwork.PlayerList.Length < 2 && m_IsLeaving == false)
            {
                m_CoinSpawner.gameObject.SetActive(false);
                if (m_MovementController)
                {
                    m_MovementController.enabled = false;
                }
                m_WeaponButton.enabled = false;
            }
            else
            {
                m_CoinSpawner.gameObject.SetActive(true);
                if (m_MovementController)
                {
                    m_MovementController.enabled = true;
                }
                m_WeaponButton.enabled = true;
                if (PhotonNetwork.PlayerList.Length < 2)
                {
                    ResultController.OnlevelEnd();
                }
            }
        }

    }
}