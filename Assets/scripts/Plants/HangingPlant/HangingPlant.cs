using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Plants
{
    public class HangingPlant : BasePlant
    {

        public GameObject[] plantstoalive;
        protected override void becomeAlive()
        {
            base.becomeAlive();
            for (int i = 0; i < plantstoalive.Length; i++)
            {
                plantstoalive[i].GetComponent<HangingPlantLadder>().activate();
            }
        }
    }
}