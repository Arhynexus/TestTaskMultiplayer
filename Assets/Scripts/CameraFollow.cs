using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private int m_FollowSpeed;
        [SerializeField] private float m_ZOffset = 10f;
        private Vector3 m_PlayerVector;
        private Transform m_Player;

        public void SetPlayer(Transform transform)
        {
            m_Player = transform;
        }

        private void Update()
        {
            if (m_Player)
            {
                m_PlayerVector = m_Player.position;
                m_PlayerVector.z = -m_ZOffset;
                transform.position = Vector3.Lerp(transform.position, m_PlayerVector, m_FollowSpeed * Time.deltaTime);
            }
        }
    }
}