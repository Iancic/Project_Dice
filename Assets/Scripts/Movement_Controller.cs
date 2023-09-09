using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Movement_Controller : MonoBehaviour
{
    public UnityEvent left_event = new();
    public UnityEvent right_event = new();
    public UnityEvent down_event = new();
    public UnityEvent up_event = new();
    public GameObject button;

    void Start()
    {
        button = this.gameObject;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null && hit.collider.gameObject == gameObject) 
            {
                if (CompareTag("left"))
                    StartCoroutine(Player_Controller.Instance.moveLeft());
                else if (CompareTag("right"))
                    StartCoroutine(Player_Controller.Instance.moveRight());
                else if (CompareTag("down"))
                    StartCoroutine(Player_Controller.Instance.moveDown());
                else if (CompareTag("up"))
                    StartCoroutine(Player_Controller.Instance.moveUp());
            }
        }
    }
}
