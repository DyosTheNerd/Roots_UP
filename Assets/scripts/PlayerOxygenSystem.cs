using System;
using UnityEngine;

public class PlayerOxygenSystem : MonoBehaviour
{
    
    public int oxygenCollisions = 0;
    
    private int maxO2 = 1000;

    private int lossPerTick = 1;

    private int rechargePerTick = 5;
    
    private int currentO2 = 1000;

    public int getCurrentO2()
    {
        return currentO2;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Console.Write("collision enter");
        if (other.gameObject.CompareTag("OxygenSource") )
        {
            oxygenCollisions += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Console.Write("collision exit");
        if (other.gameObject.CompareTag("OxygenSource"))
        {
            oxygenCollisions -= 1;
        }
    }


    bool canLooseOxygen()
    {
        return currentO2 > 0;
    }

    bool isInsideOxygenSource()
    {
        
        return oxygenCollisions > 0;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
        if (canLooseOxygen() && !isInsideOxygenSource())
        {
            currentO2 -= lossPerTick;
        }

        if (isInsideOxygenSource())
        {
            currentO2 += rechargePerTick;
            currentO2 = Math.Min(currentO2, maxO2);
        }
        
    }
}
