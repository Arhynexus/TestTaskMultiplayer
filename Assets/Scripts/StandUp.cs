using UnityEngine;

namespace TestTaskMultiPlayer
{

    public class StandUp : MonoBehaviour
    {

        private void LateUpdate()
        {
            transform.up = Vector2.up;
        }
    }
}
