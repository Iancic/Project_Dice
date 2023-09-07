using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor_Selector : MonoBehaviour
{
    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetGame() 
    { 

    }
}
