using System;
using DefaultNamespace;
using UnityEngine;

public class BasePlant : BaseInteractable
{
    
    public int maxLife = 100;
    public int oxygenProductionThreshold = 80;

    public GameObject oxygenZone;
        
    public int currentLife = 0;

    public bool isAlive = false;
    
    public int regenRate = 6;

    void Start()
    {
        
    }


    void Update()
    {
        if (!isAlive)
        {
            checkBecomeAlive();
        }
        

    }

    public override void interact()
    {
        regenLife();
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
