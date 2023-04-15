using Photon.Pun;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class Bag : MonoBehaviour
    {
        private int m_Money;
        public PhotonView m_View;

        private void Start()
        {
            m_View = GetComponent<PhotonView>();
        }

        [PunRPC]
        public void AddMoney(int money)
        {
            m_Money += money;
        }
    }
}
