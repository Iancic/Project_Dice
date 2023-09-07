using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Current_Level : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.SetText(SceneManager.GetActiveScene().name);
    }
}
