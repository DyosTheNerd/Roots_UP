using System;
using DefaultNamespace;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePlant : MonoBehaviour, SendWaterEvent
{
    
    public int maxLife = 100;
    public int oxygenProductionThreshold = 80;

    public GameObject oxygenZone;
        
    public int currentLife = 0;

    public bool isAlive = false;

    public List<Sprite> plantSpriteList = new List<Sprite>();

    public int regenRate = 6;

    public bool hasWater = false;


    public void SendWaterMessage()
    {
        hasWater = true;
        
    }

    void Update()
    {
        if (hasWater)
        {
            regenLife();
        }
        
        
        if (!isAlive)
        {
            checkBecomeAlive();
        }
        

    }
    
    

    private void regenLife()
    {
        if (currentLife < maxLife)
        {
            currentLife = Math.Min(currentLife += 6,maxLife);    
        }
    }

    private void checkBecomeAlive()
    {
        if (currentLife >= maxLife)
        {
            isAlive = true;
            initializeOxygen();
        }
    }

    private void initializeOxygen()
    {
        oxygenZone.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        oxygenZone.gameObject.layer = LayerMask.NameToLayer("Atmosphere");
        oxygenZone.gameObject.tag = "OxygenSource";
    }
    
}
