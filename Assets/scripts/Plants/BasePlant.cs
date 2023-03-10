using System;
using DefaultNamespace;
using UnityEngine;
using System.Collections.Generic;

public class BasePlant : MonoBehaviour, SendWaterEvent
{
    
    public int maxLife = 100;
    public int oxygenProductionThreshold = 80;

    public GameObject oxygenZone;
    public GameObject particleeffect;

    public int currentLife = 0;

    public bool isAlive = false;

    public int regenRate = 6;

    public bool hasWater = false;

    public List<Sprite> plantSpriteList = new List<Sprite>();

    public Animator animator;


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

    protected void ChangeSprite(int spriteInt)
    {
        if (!name.Equals("Fungo"))
        {
            this.GetComponent<SpriteRenderer>().sprite = plantSpriteList[spriteInt];
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
            becomeAlive();
        }
    }

    protected virtual void becomeAlive()
    {
        initializeOxygen();
        ChangeSprite(1);

    }
    
    
    protected void initializeOxygen()
    {
        oxygenZone.gameObject.layer = LayerMask.NameToLayer("Atmosphere");
        oxygenZone.gameObject.tag = "OxygenSource";

        if(this.name == "Fungo")
        {
            particleeffect.SetActive(false);
            animator.SetBool("wakeup", true);
        }
        else
        {
            particleeffect.SetActive(true);
        }

    }
    
}
