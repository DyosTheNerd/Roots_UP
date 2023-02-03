using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Bar : MonoBehaviour
{
    public GameObject lifebarVisualizer;

    private int maxO2 = 1000;

    private int lossPerTick = 1;

    private int currentO2 = 1000;

    private Vector3 startScale;

    void Start()
    {
        startScale = lifebarVisualizer.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (canLooseOxygen() && isCloseToOxygenSource())
        {
            currentO2 -= lossPerTick;
        }

        lifebarVisualizer.transform.localScale = new Vector3(startScale.x * currentO2 / 1000, startScale.y , startScale.z);
        
    }

    bool canLooseOxygen()
    {
        return currentO2 > 0;
    }

    bool isCloseToOxygenSource()
    {
        return false;
    }
    
}
