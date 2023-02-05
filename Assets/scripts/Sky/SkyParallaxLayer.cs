using UnityEngine;

namespace DefaultNamespace.Sky
{
    public class SkyParallaxLayer : MonoBehaviour, SkyEvent
    {
        public float factor;
        
        public void DeltaEvent(Vector3 current, Vector3 old)
        {
            Vector3 delta = current - old;

            Vector3 delta2d = new Vector3(delta.x, delta.y, 0);
            
            Vector3 factorDelta =  (delta2d * factor);

            gameObject.transform.position = gameObject.transform.position + factorDelta;
        }
    }
}