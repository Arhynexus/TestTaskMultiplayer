using Photon.Pun;
using UnityEngine;

namespace TestTaskMultiPlayer
{
    public class TankSetup : MonoBehaviour
    {
        public PhotonView m_ViewSetup;
        public GameObject m_Tank;
        public int CharacterValue;


        private void Start()
        {
            m_ViewSetup = GetComponent<PhotonView>();
        }

        [PunRPC]
        private void RPC_AddCharacter(int whichCharacter)
        {
            CharacterValue = whichCharacter;
        }

    }
}
