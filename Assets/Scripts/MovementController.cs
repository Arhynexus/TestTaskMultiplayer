using UnityEngine;
using Photon.Pun;

namespace TestTaskMultiPlayer
{


    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float m_PlayerSpeed;
        [SerializeField] private float m_PlayerRotationSpeed;
        private Virtual_Joystick m_PlayerJoystick;

        public PhotonView m_PlayerView { get; private set; }
        private void Start()
        {
            m_PlayerJoystick = FindObjectOfType<Virtual_Joystick>();
            m_PlayerView = GetComponent<PhotonView>();
        }

        private void Update()
        {
            float moveInputhorizontal = m_PlayerJoystick.value.x;
            float moveInputvertictal = m_PlayerJoystick.value.y;
            if (m_PlayerView.IsMine)
            {
                transform.Rotate(Vector3.forward * moveInputhorizontal * m_PlayerRotationSpeed * Time.deltaTime);
                transform.Translate(-Vector2.up * moveInputvertictal * m_PlayerSpeed * Time.deltaTime);
            }
        }
    }
}