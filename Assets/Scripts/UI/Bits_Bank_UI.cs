using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bits_Bank_UI : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.SetText("Bits Total " + Player_Controller.Instance.bits_bank.ToString());
    }
}
