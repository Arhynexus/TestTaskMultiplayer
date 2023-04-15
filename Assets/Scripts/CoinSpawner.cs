using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class CoinSpawner : MonoBehaviourPun
    {
        [SerializeField] private Coin m_CoinPrefab;
        [SerializeField] private float m_SpawnRate;
        [SerializeField] private int m_MaxSpawned = 20;
        public int MaxSpawned => m_MaxSpawned;
        private List<Coin> m_AmountSpawned;
        private float m_Timer;
        private float m_CheckCoinsTimer = 60;
        private void Start()
        {
            if (m_AmountSpawned == null)
            {
                m_AmountSpawned = new List<Coin>();
            }
            m_Timer = m_SpawnRate;
        }

        private void SpawnCoin()
        {
            Vector2 startPosition = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
            var coin = PhotonNetwork.Instantiate(m_CoinPrefab.name, startPosition, Quaternion.identity).GetComponent<Coin>();
            m_AmountSpawned.Add(coin);
            print("Added" + coin.name);
        }

        private void Update()
        {
            m_Timer -= Time.deltaTime;
            m_CheckCoinsTimer -= Time.deltaTime;
            if (m_Timer < 0 && m_AmountSpawned.Count < m_MaxSpawned)
            {
                SpawnCoin();
                m_Timer = m_SpawnRate;
            }
            if (m_CheckCoinsTimer < 0)
            {
                if(FindObjectsOfType<Coin>().Length < 1)
                {
                    m_AmountSpawned.Clear();
                }
            }
        }
    }
}
