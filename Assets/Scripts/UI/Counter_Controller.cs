using TMPro;
using UnityEngine;

public class Counter_Controller : MonoBehaviour
{
    public TMP_Text text;
    public float counter = 1f;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        counter += 1f * Time.deltaTime;
        text.SetText(Mathf.Round(counter).ToString());
    }
}
