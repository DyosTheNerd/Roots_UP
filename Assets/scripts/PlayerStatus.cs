using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStatus : MonoBehaviour, PlayerDyingEvent
    {

        private bool isDead = false;
        private bool canMove = true;

        public bool IsDead
        {
            get => isDead;
        }

        public bool CanMove
        {
            get => canMove;
        }

        public void DyingMessage(string reason)
        {
            Debug.Log("dead");

            isDead = true;
            canMove = false;
        }
    }
}