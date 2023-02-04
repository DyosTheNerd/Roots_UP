using Unity.VisualScripting;
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

            // Death haha screw ur damn events nobody needs them ~ Luca
            GameObject canv = GameObject.Find("Canvas");
            canv.transform.GetChild(0).gameObject.SetActive(true);


            canMove = false;
        }
    }
}