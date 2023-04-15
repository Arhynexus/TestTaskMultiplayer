using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace TestTaskMultiPlayer
{
    public class UpdateHealthUI : MonoBehaviourPun
    {
        [SerializeField] private Destructible m_PlayerDestructible;
        [SerializeField] private Image m_HealthBarImage;

        private void Start()
        {
            m_PlayerDestructible.OnHealthChanged += UpdateHealthBar;
        }

        [PunRPC]
        public void UpdateHealthBar()
        {
            float maxHealth = m_PlayerDestructible.MaxHealthPoints;
            float health = m_PlayerDestructible.CurrentHealthPoints;
            m_HealthBarImage.fillAmount = health / maxHealth;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
