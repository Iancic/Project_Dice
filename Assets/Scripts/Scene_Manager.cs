using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Scene_Manager : MonoBehaviour
{

    //This if checks the version and puts game ID key accordingly
    public static Scene_Manager Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    //Singleton Workflow

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
