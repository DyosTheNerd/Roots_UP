using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStatus : MonoBehaviour, PlayerDyingEvent
    {

        public bool isDead = false;
        private bool canMove = true;
        

        public Animator animator;

        public List<AudioClip> soundList = new List<AudioClip>();

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
            
            AudioSource myAudioSrc = this.gameObject.GetComponent<AudioSource>();   // ab hier änderungen
            myAudioSrc.enabled = true;
            myAudioSrc.clip = soundList[0];
            myAudioSrc.Play();

            //versuch den sound von main camera auszuschalten
            AudioSource lohl =  GameObject.Find("Main Camera").GetComponent<AudioSource>();   // ab hier änderungen
            lohl.enabled = false;


            canMove = false;
        }
    }
}
