using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bits_UI : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.SetText("Bits " + Player_Controller.Instance.bits.ToString());
    }
}
