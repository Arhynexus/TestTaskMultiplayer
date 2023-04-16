using Photon.Pun;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TestTaskMultiPlayer
{
    public class ResultController : MonoBehaviourPun
    {
        [SerializeField] private Text m_TextPrefab;
        [SerializeField] private GameController m_GameController;
        [SerializeField] private GameObject m_ResultPanel;
        [SerializeField] private GameObject m_ReslutsPanelIsParentForTexts;

        PhotonView m_ResultControllerView;

        public static Action OnlevelEnd;
        private void Start()
        {
            m_ResultControllerView = GetComponent<PhotonView>();
            m_ResultPanel.SetActive(false);
            OnlevelEnd += ActivateShowResults;
            foreach (var text in m_ReslutsPanelIsParentForTexts.GetComponentsInChildren<Text>())
            {
                Destroy(text.gameObject);
            }
        }

        public void ActivateShowResults()
        {
            m_ResultControllerView.RPC("ShowResults", RpcTarget.AllBuffered);
        }

        [PunRPC]
        public void ShowResults()
        {
            foreach (var oldtext in m_ReslutsPanelIsParentForTexts.GetComponentsInChildren<Text>())
            {
                Destroy(oldtext.gameObject);
            }

            foreach (var player in m_GameController.Tanks.OrderByDescending(p => p.GetComponent<Bag>().Coins))
            {
                m_ResultPanel.SetActive(true);
                var text = Instantiate(m_TextPrefab);
                text.transform.SetParent(m_ReslutsPanelIsParentForTexts.transform, false);
                text.text = player.m_DestructibleView.Owner.NickName + " " + player.GetComponent<Bag>().Coins.ToString();
            }
            Time.timeScale = 0;
        }
    }
}
