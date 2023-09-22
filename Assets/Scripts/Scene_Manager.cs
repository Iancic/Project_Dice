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

    public void LoadSceneA()
    {
        SceneManager.LoadScene("Level_A");
    }

    public void LoadSceneB()
    {
        SceneManager.LoadScene("Level_B");
    }

    public void LoadSceneC()
    {
        SceneManager.LoadScene("Level_C");
    }

    public void LoadSceneD()
    {
        SceneManager.LoadScene("Level_D");
    }

    public void LoadSceneE()
    {
        SceneManager.LoadScene("Level_E");
    }

    public void LoadSceneF()
    {
        SceneManager.LoadScene("Level_F");
    }

    public void LoadSceneG()
    {
        SceneManager.LoadScene("Level_G");
    }

    public void LoadSceneH()
    {
        SceneManager.LoadScene("Level_H");
    }

    public void LoadSceneI()
    {
        SceneManager.LoadScene("Level_I");
    }

    public void LoadSceneJ()
    {
        SceneManager.LoadScene("Level_J");
    }

    public void LoadSceneK()
    {
        SceneManager.LoadScene("Level_K");
    }

    public void LoadSceneL()
    {
        SceneManager.LoadScene("Level_L");
    }

    public void LoadSceneM()
    {
        SceneManager.LoadScene("Level_M");
    }

    public void LoadSceneN()
    {
        SceneManager.LoadScene("Level_N");
    }

    public void LoadSceneO()
    {
        SceneManager.LoadScene("Level_O");
    }

    public void LoadSceneP()
    {
        SceneManager.LoadScene("Level_P");
    }

    public void LoadSceneQ()
    {
        SceneManager.LoadScene("Level_Q");
    }

    public void LoadSceneR()
    {
        SceneManager.LoadScene("Level_R");
    }

    public void LoadSceneS()
    {
        SceneManager.LoadScene("Level_S");
    }

    public void LoadSceneT()
    {
        SceneManager.LoadScene("Level_T");
    }

    public void LoadSceneU()
    {
        SceneManager.LoadScene("Level_U");
    }

    public void LoadSceneV()
    {
        SceneManager.LoadScene("Level_V");
    }

    public void LoadSceneW()
    {
        SceneManager.LoadScene("Level_W");
    }

    public void LoadSceneX()
    {
        SceneManager.LoadScene("Level_X");
    }

    public void LoadSceneY()
    {
        SceneManager.LoadScene("Level_Y");
    }

    public void LoadSceneZ()
    {
        SceneManager.LoadScene("Level_Z");
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

    public void Level_Selector()
    {
        SceneManager.LoadScene("Level_Selector");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
