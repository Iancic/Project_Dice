using TMPro;
using UnityEngine;

public class Rounds_UI : MonoBehaviour
{
    public TMP_Text text;
    
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.SetText("Round " + " " + Player_Controller.Instance.round.ToString());
    }
}
