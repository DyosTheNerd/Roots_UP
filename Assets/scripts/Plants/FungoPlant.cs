using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FungoPlant : BasePlant
{
    protected override void becomeAlive()
    {
        initializeOxygen();

        StartCoroutine(activatewin());
    }

    IEnumerator activatewin()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("EobsaBGIoaNIBO");
        GameObject canv = GameObject.Find("Canvas");
        

        canv.transform.GetChild(1).gameObject.SetActive(true);
        //canv.transform.GetChild(2).gameObject.SetActive(true);


    }

}
