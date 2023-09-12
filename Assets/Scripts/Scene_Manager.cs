using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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

    public void Endless()
    {
        SceneManager.LoadScene("Endless Mode");
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player_Controller.Instance.bits_bank = Player_Controller.Instance.bits;
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
