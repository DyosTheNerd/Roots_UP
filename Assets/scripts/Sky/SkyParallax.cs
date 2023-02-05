using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Player;
using DefaultNamespace.Sky;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkyParallax : MonoBehaviour
{

    private Vector3 lastV3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentV3 = PlayerSingletonProvider.getPlayerGameObject().transform.position;
        
        if (lastV3 != null)
        {
            transformParallax(currentV3, lastV3);
        }


        lastV3 = currentV3;

    }

    private void transformParallax(Vector3 current, Vector3 old)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            ExecuteEvents.Execute<SkyEvent>(gameObject.transform.GetChild(i).gameObject, null, (x, y) => x.DeltaEvent(current,old));
        }
    }
    
}
