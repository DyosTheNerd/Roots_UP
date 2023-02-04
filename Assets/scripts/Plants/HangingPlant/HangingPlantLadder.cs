using UnityEngine;

namespace DefaultNamespace.Plants
{
    public class HangingPlantLadder : MonoBehaviour, InteractionEvent, TogglePlantAliveEvent
    {

        private bool isAlive = false;

        public Sprite aliveSprite;
        
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
            this.GetComponent<SpriteRenderer>().sprite = aliveSprite;
            Debug.Log("HaningPlantisAlive");
        }
    }
}