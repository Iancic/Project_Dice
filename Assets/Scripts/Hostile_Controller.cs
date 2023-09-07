using UnityEngine;
using System.Collections;

public class Hostile_Controller : MonoBehaviour
{
    public float moveSpeed = 5f; //hostile moving speed
    public float slideValue = 2f;
    public Transform hostile_pos;
    public Transform movePoint; //movepoint
    public Transform Target;

    public float distance_y, distance_x;
    public float player_x, player_y;

    public LayerMask whatStopsMovement;

    public bool executie = false;

    void Start()
    {
        hostile_pos = GetComponent<Transform>();
        movePoint.parent = null;
    }

    void Update()
    {
        player_y = Player_Controller.Instance.player_pos.position.y;
        player_x = Player_Controller.Instance.player_pos.position.x;
        distance_x = movePoint.transform.position.x - player_x;
        distance_y = movePoint.transform.position.y - player_y;
        //distantele

        hostile_pos.position = Vector3.MoveTowards(hostile_pos.position, movePoint.position, moveSpeed * Time.deltaTime);
        //The player always move to the target position. We don't move the player we move the target, the player will follow it. I can make this slower by doing this moveSpeed/2.

        if (Player_Controller.Instance.stage == 2 && executie == false)
        {
            executie = true;
            StartCoroutine(MovementEnemy());
        }
        //cand rulez miscarea
    }

    public IEnumerator MovementEnemy()
    {
        yield return new WaitForSeconds(1.2f);

        if (Vector3.Distance(hostile_pos.position, movePoint.position) <= 0.5f)
        {
            for (int i = 1; i <= slideValue; i++)
            {
                Debug.Log("rules");
                yield return new WaitForSeconds(0.3f);
                if (Mathf.Abs(distance_x) >= 0.2f)
                {
                    if (distance_x < 0f)
                    {
                        if (!Physics2D.OverlapBox(movePoint.position + new Vector3(1f, 0f, 0f), new Vector2(0.2f, 0.1f), whatStopsMovement))
                        {
                            movePoint.position += new Vector3(1f, 0f, 0f);
                        }
                        yield return new WaitForSeconds(0.3f);
                    }

                    else if (distance_x > 0f)
                    {
                        if (!Physics2D.OverlapBox(movePoint.position + new Vector3(-1f, 0f, 0f), new Vector2(0.2f, 0.1f), whatStopsMovement))
                        {
                            movePoint.position -= new Vector3(1f, 0f, 0f);
                        }
                        yield return new WaitForSeconds(0.5f);
                    }
                }

                if (Mathf.Abs(distance_y) >= 0.2f)
                {
                    if (distance_y < 0f)
                    {
                        if (!Physics2D.OverlapBox(movePoint.position + new Vector3(0f, 1f, 0f), new Vector2(0.2f, 0.1f), whatStopsMovement))
                        {
                            movePoint.position += new Vector3(0f, 1f, 0f);
                        }
                        yield return new WaitForSeconds(0.5f);
                    }

                    else if (distance_y > 0f)
                    {
                        if (!Physics2D.OverlapBox(movePoint.position + new Vector3(0f, -1f, 0f), new Vector2(0.2f, 0.1f), whatStopsMovement))
                        {
                            movePoint.position -= new Vector3(0f, 1f, 0f);
                        }
                        yield return new WaitForSeconds(0.5f);
                    }
                }

                Player_Controller.Instance.stage = 1;
                executie = false;
            }
        }
    }

}
