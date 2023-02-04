using DefaultNamespace.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Plants
{
    public class HangingPlantLadder : MonoBehaviour
    {

        public bool climbable = false;
        SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (climbable)
            {
                spriteRenderer.enabled = true;
            }
        }

        public void activate()
        {
            spriteRenderer.enabled = true;
            climbable = true;
        }

        public void deactivate()
        {
            spriteRenderer.enabled = false;
            climbable = false;
        }

    }

    
}