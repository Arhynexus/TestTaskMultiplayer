using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTaskMultiPlayer
{


    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject m_PlayerPrefab;
        [SerializeField] private float StartSpawnPositionMinX, StartSpawnPositionMinY, StartSpawnPositionMaxX, StartSpawnPositionMaxY;

        private void Start()
        {
            Vector2 startPosition = new Vector2(Random.Range(StartSpawnPositionMinX, StartSpawnPositionMaxX), Random.Range(StartSpawnPositionMinY, StartSpawnPositionMaxY));

            GamePlayer.Instance.SetPlayer(PhotonNetwork.Instantiate(m_PlayerPrefab.name, startPosition, Quaternion.identity));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}