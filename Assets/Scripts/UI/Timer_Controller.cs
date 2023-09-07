using UnityEngine;
using UnityEngine.UI;

public class Timer_Controller : MonoBehaviour
{
    public GameObject Lose_Screen, Game_Screen;
    public Image timer;

    static public float time_remaining;
    private float max_time = 10f;

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

        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            timer.fillAmount = time_remaining / max_time;
        }

        else
        {
            Lose_Screen.SetActive(true);
            Game_Screen.SetActive(false);
        }
    }
}
