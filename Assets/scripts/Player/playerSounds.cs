using DefaultNamespace;
using DefaultNamespace.Player;
using UnityEngine;

public class PlayerSounds : MonoBehaviour,PlayerActionMessages{

public GameObject soundlib;

public void Update()
    {
     
         /*   ExecuteEvents.Execute<PlayerActionMessages>(gameObject, null, (x, y) => x.OnPlayerJumped());
            jumped = false;
    
            ExecuteEvents.Execute<PlayerActionMessages>(gameObject, null, (x, y) => x.OnPlayerClimbing());
            isClimbing = false;
            */    
      
    }

    public void OnPlayerClimbing() {
            AudioSource climbSound = this.gameObject.GetComponent<AudioSource>();
            climbSound.enabled     = true;
            climbSound.Play(); 


    }

    public void OnPlayerJumped() {
            AudioSource jumpSound = this.gameObject.GetComponent<AudioSource>();
            jumpSound.enabled     = true;
            jumpSound.Play();

    }










/*

 private void climbingsound() {
    

            ExecuteEvents.Execute<PlayerActionMessages>(playerCharacter, null, isClimbing) 
             
 }


 private void jumpSound() {

            ExecuteEvents.Execute<PlayerActionMessages>(playerCharacter, null, jumped)
              
 }


 run() {
    climbingsound();
    jumpSound();
 }


 
*/
}
