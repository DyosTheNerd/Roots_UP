using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public void LoadScene()
    {
        print("Load");
        SceneManager.LoadScene(1);
    }
}
