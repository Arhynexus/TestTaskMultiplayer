using Photon.Pun;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class Bag : MonoBehaviour
    {
        public int Money { get; private set; }

        public int Coins { get; private set; }
        public PhotonView m_View;


        private void Start()
        {
            m_View = GetComponent<PhotonView>();
        }

        [PunRPC]
        public void AddMoney(int money)
        {
            Money += money;
            Coins++;
            UpdateMoneyUI.OnCoinCollected();
        }
    }
}
