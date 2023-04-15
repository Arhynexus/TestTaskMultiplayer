using Photon.Pun;
using System;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class Destructible : MonoBehaviour
    {
        [SerializeField] private int m_MaxHealthtpoints;
        public int MaxHealthPoints => m_MaxHealthtpoints;
        public int CurrentHealthPoints { get; private set; }

        public PhotonView m_DestructibleView;

        public event Action OnHealthChanged;

        private void Start()
        {
            m_DestructibleView = GetComponent<PhotonView>();
            CurrentHealthPoints = m_MaxHealthtpoints;
        }
        [PunRPC]
        public void ApplyDamage(int m_damage)
        {
            CurrentHealthPoints -= m_damage;
            if (CurrentHealthPoints <= 0)
            {
                CurrentHealthPoints = 0;
                m_DestructibleView.RPC("Death", RpcTarget.MasterClient);
            }
            OnHealthChanged();
        }
        [PunRPC]
        public void Death()
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}