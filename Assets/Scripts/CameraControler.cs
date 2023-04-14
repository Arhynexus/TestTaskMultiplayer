using UnityEngine;
using Photon.Pun;

namespace TestTaskMultiPlayer
{

    public class CameraControler : MonoBehaviourPunCallbacks
    {
        private MovementController m_MovementController;
        private void Start()
        {
            m_MovementController = GetComponent<MovementController>();
            if (m_MovementController.m_PlayerView.Owner.IsLocal)
            {
                Camera.main.GetComponent<CameraFollow>().SetPlayer(gameObject.transform);
            }
        }

        private void Update()
        {

        }
    }
}