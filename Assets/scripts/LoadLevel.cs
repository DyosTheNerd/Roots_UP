using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadScene()
    {
        print("Load");
        SceneManager.LoadScene(1);
    }
}
