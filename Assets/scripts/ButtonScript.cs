using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public void respawn()
    {
        SceneManager.LoadScene("level_one_v2");
    }

    public void quit()
    {
        Debug.Log("QUITTING");
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
