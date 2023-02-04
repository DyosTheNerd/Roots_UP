using DefaultNamespace.Player;
using UnityEngine;
using UnityEngine.EventSystems;

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
                setPlayerClimbing();
            }
        }

        private void setPlayerClimbing()
        {
            
            ExecuteEvents.Execute<PlayerClimbingEvent>(PlayerSingletonProvider.getPlayerGameObject(), null, (x, y) => x.PlayerClimbingMessage());        
        }

        public void TogglePlantAliveMessage()
        {
            isAlive = true;
            GetComponent<SpriteRenderer>().sprite = aliveSprite;
        }
    }
}