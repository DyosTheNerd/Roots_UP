using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FungoPlant : BasePlant
{
    protected new void becomeAlive()
    {
        initializeOxygen();
        activatewin();
    }

    private void activatewin()
    {
        GameObject canv = GameObject.Find("Canvas");
        canv.transform.GetChild(1).gameObject.SetActive(true);
    }

    protected new void ChangeSprite(int spriteInt)
    {
    }

}
