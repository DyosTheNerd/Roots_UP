using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Plants
{
    public class HangingPlant : BasePlant
    {

        public GameObject plantAliveObject;
        protected override void becomeAlive()
        {
            base.becomeAlive();
            ExecuteEvents.Execute<TogglePlantAliveEvent>(plantAliveObject, null, (x, y) => x.TogglePlantAliveMessage());            
        }
    }
}