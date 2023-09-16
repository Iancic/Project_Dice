using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using static Cinemachine.DocumentationSortingAttribute;

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

    public IEnumerator Intro()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level Selector");
    }

    public void NextScene()
    {
        int level = Random.Range(3, 4);
        switch (level)
        {
            case 3:
                SceneManager.LoadScene("Level_3");
                break;
            case 4:
                SceneManager.LoadScene("Level_4");
                break;
            case 5:
                SceneManager.LoadScene("Level_5");
                break;
            case 6:
                SceneManager.LoadScene("Level_6");
                break;
            case 7:
                SceneManager.LoadScene("Level_7");
                break;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
