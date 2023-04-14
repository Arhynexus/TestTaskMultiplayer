using UnityEngine;
using Photon.Pun;

namespace TestTaskMultiPlayer
{
    public class Projectile : MonoBehaviour, IPunObservable
    {
        [SerializeField] private float m_Velocity;
        public float Velocity => m_Velocity;
        [SerializeField] private float lifeTime;
        [SerializeField] private int m_damage;
        [SerializeField] private ImpactEffect m_ImpactEffectPrefab_01;
        [SerializeField] private ImpactEffect m_ImpactEffectPrefab_02;

        private PhotonView m_BulletView;

        protected virtual void Start()
        {
            m_BulletView = GetComponent<PhotonView>();
            m_BulletView.ObservedComponents.Add(this);
        }

        protected virtual void Update()
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                PhotonNetwork.Destroy(gameObject);
            }


            float stepLength = Time.deltaTime * m_Velocity;
            Vector2 step = transform.up * stepLength;

            if(m_BulletView.IsMine)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLength);

                if (hit)
                {
                    Destructible dest = hit.collider.transform.GetComponentInParent<Destructible>();

                    if (dest != null && dest != m_Parent)
                    {
                        dest.ApplyDamage(m_damage);
                        OnProjectileLifeEnd(hit.collider, hit.point);
                    }
                }
                transform.position += new Vector3(step.x, step.y, 0);
            }

        }

        protected virtual void OnTriggerEnter2D(Collider2D collision) { }

        protected virtual void OnProjectileLifeEnd(Collider2D collider, Vector2 point)
        {
            if (m_ImpactEffectPrefab_01 != null)
            {
                Instantiate(m_ImpactEffectPrefab_01, transform.position, Quaternion.identity);
            }
            if (m_ImpactEffectPrefab_02 != null)
            {
                Instantiate(m_ImpactEffectPrefab_02, transform.position, Quaternion.identity);
            }
            PhotonNetwork.Destroy(gameObject);
        }

        private Destructible m_Parent;
        public void SetParentShooter(Destructible parent)
        {
            m_Parent = parent;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            
        }
    }
}
