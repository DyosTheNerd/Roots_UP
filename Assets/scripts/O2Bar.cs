using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Bar : MonoBehaviour
{
    public GameObject lifebarVisualizer;


    public GameObject playerObject;

    private Vector3 startScale;

    private PlayerOxygenSystem _oxygenSystem;

    void Start()
    {
        _oxygenSystem = playerObject.GetComponent<PlayerOxygenSystem>();
        startScale = lifebarVisualizer.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        
        float currentO2 = _oxygenSystem.getCurrentO2();

        lifebarVisualizer.transform.localScale = new Vector3(startScale.x * currentO2 / 1000, startScale.y , startScale.z);
        
    }

  
    
}
