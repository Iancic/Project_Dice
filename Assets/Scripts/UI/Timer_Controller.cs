using UnityEngine;
using UnityEngine.UI;

public class Timer_Controller : MonoBehaviour
{
    public static Timer_Controller Instance { get; private set; }

    public GameObject Lose_Screen, Game_Screen;
    public Image timer;

    static public float time_remaining;
    private float max_time = 10f;

    public int gamePaused = 0;
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
        if (time_remaining > max_time) 
        {
            time_remaining = max_time;
        }

        if (time_remaining > 0 && gamePaused == 0)
        {
            time_remaining -= Time.deltaTime;
            timer.fillAmount = time_remaining / max_time;
        }

        else
        {
            Lose_Screen.SetActive(true);
            Game_Screen.SetActive(false);
            Player_Controller.Instance.DisableDirections();
            gamePaused = 1;
        }
    }
}
