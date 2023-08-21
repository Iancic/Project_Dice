using UnityEngine;
using UnityEngine.Events;

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
                if(CompareTag("left"))
                    left_event.Invoke();
                else if (CompareTag("right"))
                    right_event.Invoke();
                else if (CompareTag("down"))
                    down_event.Invoke();
                else if (CompareTag("up"))
                    up_event.Invoke();
            }
        }
    }
}
