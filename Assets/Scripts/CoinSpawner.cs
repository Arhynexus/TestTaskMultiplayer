using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class CoinSpawner : MonoBehaviourPun
    {
        [SerializeField] private Coin m_CoinPrefab;
        [SerializeField] private float m_SpawnRate;
        private float m_Timer;
        void Start()
        {
            m_Timer = m_SpawnRate;
            SpawnCoin();
        }

        private void SpawnCoin()
        {
            Vector2 startPosition = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
            var coin = PhotonNetwork.Instantiate(m_CoinPrefab.name, startPosition, Quaternion.identity).GetComponent<Coin>();
        }

        // Update is called once per frame
        void Update()
        {
            m_Timer -= Time.deltaTime;
            if(m_Timer < 0 )
            {
                SpawnCoin();
                m_Timer = m_SpawnRate;
            }
        }
    }
}
