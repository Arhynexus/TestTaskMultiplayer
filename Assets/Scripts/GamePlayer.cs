using UnityEngine;
using Photon.Pun;

namespace TestTaskMultiPlayer
{
    public class GamePlayer : SingletonBase<GamePlayer>
    {
        public Tank Tank { get; private set; }
        private Turret m_PlayerTurret;

        public void Fire()
        {
            m_PlayerTurret.Fire();
        }

        public void SetPlayer(GameObject gameObject)
        {
            Tank = gameObject.GetComponent<Tank>();
            m_PlayerTurret = Tank.GetComponentInChildren<Turret>();
        }
    }
}
