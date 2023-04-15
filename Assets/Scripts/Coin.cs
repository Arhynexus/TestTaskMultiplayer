using Photon.Pun;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class Coin : MonoBehaviourPun
    {
        [SerializeField] private int m_Amount;

        PhotonView m_CoinView;

        private void Start()
        {
            m_CoinView = GetComponent<PhotonView>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Bag bag = collision.transform.root.GetComponent<Bag>();
            if (bag)
            {
                bag.m_View.RPC("AddMoney", RpcTarget.AllBuffered, m_Amount);
                m_CoinView.RPC("DestroyCoin", RpcTarget.MasterClient);
            }
        }

        [PunRPC]
        private void DestroyCoin()
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
