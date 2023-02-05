using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public void respawn()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        SceneManager.LoadScene("01Start");
        //Debug.Log("QUITTING");
        //Application.Quit();
    }

    public void backtomenu()
    {
        SceneManager.LoadScene("01Start");
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
