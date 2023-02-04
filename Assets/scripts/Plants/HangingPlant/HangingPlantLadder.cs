using UnityEngine;

namespace DefaultNamespace.Plants
{
    public class HangingPlantLadder : MonoBehaviour, InteractionEvent, TogglePlantAliveEvent
    {

        private bool isAlive = false; 
        
        public void InteractMessage()
        {
            if (isAlive)
            {
                disablePlayerGravity();
            }
        }

        private void disablePlayerGravity()
        {
            // TODO
        }

        public void TogglePlantAliveMessage()
        {
            isAlive = true;
            
            Debug.Log("HaningPlantisAlive");
        }
    }
}