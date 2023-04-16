using UnityEngine;
using UnityEngine.UI;

namespace TestTaskMultiPlayer
{
    public class Tank : Destructible
    {
        [SerializeField] private Text m_NickNameText;
        private GameController m_Controller;

        protected override void Start()
        {
            base.Start();
            m_Controller = FindObjectOfType<GameController>();
            m_Controller.AddTankToList(this);
        }

        private void Update()
        {
            m_NickNameText.text = m_DestructibleView.Owner.NickName;
        }

    }
}