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
                setPlayerClimbing(true);
            }
        }

        public void StopInteractMessage()
        {
            if (isAlive)
            {
                setPlayerClimbing(false);
                
            }
        }

        private void setPlayerClimbing(bool isClimbing)
        {
            
            ExecuteEvents.Execute<PlayerClimbingEvent>(PlayerSingletonProvider.getPlayerGameObject(), null, (x, y) => x.PlayerClimbingMessage(isClimbing));        
        }

        public void TogglePlantAliveMessage()
        {
            isAlive = true;
            GetComponent<SpriteRenderer>().sprite = aliveSprite;
        }
    }
}