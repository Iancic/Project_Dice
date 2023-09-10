using TMPro;
using UnityEngine;

public class Counter_Controller : MonoBehaviour
{
    public TMP_Text text;
    public float counter = 10f;
    public bool executie = false;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (Player_Controller.Instance.stage == 2)
        {
            executie = false;
        }

        if (Player_Controller.Instance.stage == 1)
        {
            if (!executie) 
            {
                counter = 10f;
                executie = true;
            }
            if (executie) 
            {
                counter -= 1f * Time.deltaTime;
                text.SetText(Mathf.Round(counter).ToString());
            }
            if (counter <= 0f)
            {
                Player_Controller.Instance.round += 1;
                Player_Controller.Instance.stage = 2;
            }
        }
    }
}
