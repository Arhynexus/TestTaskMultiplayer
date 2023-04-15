using Photon.Pun;
using UnityEngine;


namespace TestTaskMultiPlayer
{
    public class PlayersControls : MonoBehaviour
    {
        [SerializeField] private Tank m_Tank;
        [SerializeField] private Turret m_PlayerTurret;
        private PointerClickHold m_WeaponButton;
        private PhotonView m_View;


        private void Start()
        {
            m_WeaponButton = FindObjectOfType<PointerClickHold>();
            m_View = m_Tank.GetComponent<PhotonView>();
        }
        private void Update()
        {
            if (m_WeaponButton.Hold == true && m_View.IsMine)
            {
                m_PlayerTurret.Fire();
            }
        }
    }
}
