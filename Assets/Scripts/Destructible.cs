using Photon.Pun;
using System;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class Destructible:MonoBehaviour
    {
        [SerializeField] private int m_MaxHealthtpoints;
        public int MaxHealthPoints => m_MaxHealthtpoints;
        private int m_CurrentHealthPoints;

        PhotonView m_DestructibleView;

        private void Start()
        {
            m_DestructibleView = GetComponent<PhotonView>();
            m_CurrentHealthPoints = m_MaxHealthtpoints;
        }

        public void ApplyDamage(int m_damage)
        {
            m_CurrentHealthPoints -= m_damage;
            if (m_CurrentHealthPoints <= 0)
            {
                m_CurrentHealthPoints = 0;
                Death();
            }
        }
        private void Death()
        {
           if(m_DestructibleView.Owner.IsLocal)
            PhotonNetwork.Disconnect();
        }
    }
}