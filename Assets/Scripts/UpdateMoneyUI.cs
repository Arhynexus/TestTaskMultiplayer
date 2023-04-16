using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;

namespace TestTaskMultiPlayer
{
    public class UpdateMoneyUI : MonoBehaviourPun
    {
        [SerializeField] private CoinSpawner m_Spawner;
        [SerializeField] private Image m_CoinBarImage;

        public static Action OnCoinCollected;

        private Bag m_PlayerBag;

        public void SetBag(Bag bag)
        {
            m_PlayerBag = bag;
        }
        void Start()
        {
            OnCoinCollected += UpdateMoney;
        }

        [PunRPC]
        public void UpdateMoney() 
        {
            float maxCoins = m_Spawner.MaxSpawned;
            float coins = m_PlayerBag.Coins;
            m_CoinBarImage.fillAmount = coins / maxCoins;
        }
    }
}
