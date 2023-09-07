using TMPro;
using UnityEngine;

public class Streak_UI : MonoBehaviour
{
    public TMP_Text text;
    public float number, rounded_number;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        number = Player_Controller.Instance.streak;
        rounded_number = Mathf.Round(number * 100) / 100;
        text.SetText("X " + rounded_number.ToString());
    }
}