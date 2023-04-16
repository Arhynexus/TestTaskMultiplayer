using UnityEngine;

namespace TestTaskMultiPlayer
{

    public class CameraControler : MonoBehaviour
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
    }
}