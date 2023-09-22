using UnityEngine;
using UnityEngine.UI;

public class Timer_Controller : MonoBehaviour
{
    public static Timer_Controller Instance { get; private set; }

    public GameObject Lose_Screen, Win_Screen, Game_Screen;
    public Image timer;

    static public float time_remaining;
    private float max_time = 20f;

    public int gamePaused = 0, gameFreeze = 0;
    // 0 is playing, 1 is paused.

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

    void Start()
    {
        time_remaining = max_time;
    }

    void Update()
    {
        timer.fillAmount = time_remaining / max_time;

        if (time_remaining > max_time)
        {
            time_remaining = max_time;
        }

        if (time_remaining > 0 && gamePaused == 0 && gameFreeze == 0)
        {
            time_remaining -= Time.deltaTime;
        }

        else if (time_remaining <= 0)
        {
            LosePopUp();
        }
    }

    public void LosePopUp()
    {
        Lose_Screen.SetActive(true);
        Game_Screen.SetActive(false);
        Player_Controller.Instance.DisableDirections();
        gamePaused = 1;
    }

    public void WinPopUp()
    {
        Win_Screen.SetActive(true);
        Game_Screen.SetActive(false);
        Player_Controller.Instance.DisableDirections();
        gamePaused = 1;
    }
}
