using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeValve : AbstractDirectInteractable, SendWaterEvent
{
    public bool hasWater = false;

    public bool isOpen = false;

    private bool isForwardingWater = false;
    
    public GameObject[] connectedObjects;

    private BaseInteractable[] connectedInteracables; 
    

    /**
     * Event when a player changes the Valves state.
     */
    public override void ConsumeInteraction()
    {
        isOpen = true;
        Debug.Log("opening valve");
        checkWaterAndForward();
    }

    /**
     * Event when an adjacent pipe sends water.
     */
    public void SendWaterMessage()
    {
        
        
        hasWater = true;
        checkWaterAndForward();
    }
    
    private void checkWaterAndForward()
    {
        if (hasWater && isOpen && !isForwardingWater)
        {
            Debug.Log("forwarding water");
            forwardWater();
            isForwardingWater = true;
        }
        else
        {
            isForwardingWater = hasWater && isOpen;
        }
    }
    
    private void forwardWater()
    {
        for (int i = 0; i < connectedObjects.Length; i++)
        {
            ExecuteEvents.Execute<SendWaterEvent>(connectedObjects[i], null, (x, y) => x.SendWaterMessage());    
        }
    }
}
