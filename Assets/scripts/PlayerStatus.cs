using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStatus : MonoBehaviour, PlayerDyingEvent
    {

        public bool isDead = false;
        private bool canMove = true;

        public Animator animator;

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

            animator.SetBool("dead", isDead);

            canMove = false;
        }
    }
}