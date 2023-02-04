using System;
using DefaultNamespace;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Plants;
using UnityEngine.EventSystems;

public class BasePlant : MonoBehaviour, SendWaterEvent
{
    
    public int maxLife = 100;
    public int oxygenProductionThreshold = 80;

    public GameObject oxygenZone;
        
    public int currentLife = 0;

    public bool isAlive = false;

    public int regenRate = 6;

    public bool hasWater = false;

    public List<Sprite> plantSpriteList = new List<Sprite>();


    public void SendWaterMessage()
    {
        hasWater = true;

        ChangeSprite(1);

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

    private void ChangeSprite(int spriteInt)
    {

        this.GetComponent<SpriteRenderer>().sprite = plantSpriteList[spriteInt];

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
            becomeAlive();
        }
    }

    protected virtual void becomeAlive()
    {
        initializeOxygen();
        
    }
    
    
    private void initializeOxygen()
    {
        oxygenZone.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        oxygenZone.gameObject.layer = LayerMask.NameToLayer("Atmosphere");
        oxygenZone.gameObject.tag = "OxygenSource";
    }
    
}
