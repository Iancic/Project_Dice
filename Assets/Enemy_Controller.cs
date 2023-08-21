using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float distance_y, distance_x;
    public float player_x, player_y;
    public float movementSpeed = 1f;

    public LayerMask whatStopsMovementenemy;

    void Update()
    {
        player_y = Player_Controller.player_pos.position.y;
        player_x = Player_Controller.player_pos.position.x;

        distance_x = transform.position.x - player_x;
        distance_y = transform.position.y - player_y;

        if (Player_Controller.stage == 2)
        {
            if (distance_x == 0){ }
            else if (distance_x > 0)
            {
                if (!Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), .2f, whatStopsMovementenemy))
                {
                    transform.position -= new Vector3(movementSpeed, 0f, 0f);
                }
            }
            else if (distance_x < 0)
            {
                if (!Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), .2f, whatStopsMovementenemy))
                {
                    transform.position += new Vector3(movementSpeed, 0f, 0f);
                }
            }

            if (distance_y == 0) { } 
            else if (distance_y > 0)
            {
                if (!Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), .2f, whatStopsMovementenemy))
                {
                    transform.position -= new Vector3(0f, movementSpeed, 0f);
                }
            }
            else if (distance_y < 0)
            {
                if (!Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), .2f, whatStopsMovementenemy))
                {
                    transform.position += new Vector3(0f, movementSpeed, 0f);
                }
            }

            Player_Controller.stage = 1;
        }

    }

}
