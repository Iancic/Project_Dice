using TMPro;
using UnityEngine;

public class Streak_UI : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.SetText("X " + Player_Controller.Instance.streak.ToString());
    }
}