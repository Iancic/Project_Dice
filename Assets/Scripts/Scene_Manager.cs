using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using static Cinemachine.DocumentationSortingAttribute;

public class Scene_Manager : MonoBehaviour
{

    //This if checks the version and puts game ID key accordingly
    public static Scene_Manager Instance { get; private set; }
    public GameObject transEnd, transStart;

    private void Awake()
    {
        transStart.SetActive(true);
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

    public void MainMenu()
    {
        transEnd.SetActive(true);
        SceneManager.LoadScene("Intro");
    }

    public void Level_Selector()
    {
        transEnd.SetActive(true);
        SceneManager.LoadScene("Level_Selector");
    }

    public IEnumerator LoadNextScene()
    {
        transEnd.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        transEnd.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
