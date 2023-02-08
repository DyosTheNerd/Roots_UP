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

        AudioSource myAudioSrc = this.gameObject.GetComponent<AudioSource>();   // ab hier änderungen
        myAudioSrc.enabled = true;
        myAudioSrc.Play();

        //versuch den sound von main camera auszuschalten
        AudioSource lohl = GameObject.Find("Main Camera").GetComponent<AudioSource>();   // ab hier änderungen
        lohl.enabled = false;
    }


    IEnumerator activatewin()
    {
        yield return new WaitForSeconds(4f);
        GameObject canv = GameObject.Find("Canvas");


        canv.transform.GetChild(1).gameObject.SetActive(true);
        //canv.transform.GetChild(2).gameObject.SetActive(true);
    }
}
