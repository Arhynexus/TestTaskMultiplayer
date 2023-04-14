using Photon.Pun;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class Turret : MonoBehaviourPun
    {

        [SerializeField] private TurretMode m_Mode;
        public TurretMode Mode => m_Mode;

        [SerializeField] private TurretProperties m_TurretProperties;

        private float m_RefireTimer;

        public bool CanFire => m_RefireTimer <= 0;

        private Tank m_Tank;

        [SerializeField] private AudioSource m_AudioSource;

        void Start()
        {
            m_Tank = transform.root.GetComponent<Tank>();
        }


        private void Update()
        {
            if (m_RefireTimer > 0) m_RefireTimer -= Time.deltaTime;
        }
        public void Fire()
        {
            if (m_TurretProperties == null) return;

            if (m_RefireTimer > 0) return;
            Projectile projectile = PhotonNetwork.Instantiate(m_TurretProperties.ProjectilePrefab.name, transform.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.SetParentShooter(m_Tank);
            projectile.transform.position = transform.position;
            projectile.transform.up = transform.up;

            m_RefireTimer = m_TurretProperties.RateOfFire;
        }

        public void AssignLoadOut(TurretProperties props)
        {
            if (m_Mode != props.TurretMode) return;
            m_RefireTimer = 0;
            m_TurretProperties = props;
        }
    }
}


