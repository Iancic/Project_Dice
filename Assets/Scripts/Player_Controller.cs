using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public static Player_Controller Instance { get; private set; }
    public Camera_Controller Camera_Prop;

    //stage counter: stage 1 is player stage and stage 2 is enemy stage
    public int stage = 1, round = 1;

    //player variables
    public float moveSpeed = 7f; //player moving speed
    public Transform player_pos;
    public Transform movePoint; //target
    public SpriteRenderer sprite_renderer;

    //sprites dice
    public static Sprite spriteDice1, spriteDice2, spriteDice3, spriteDice4, spriteDice5, spriteDice6;
    public Sprite[] sprites = { spriteDice1, spriteDice2, spriteDice3, spriteDice4, spriteDice5, spriteDice6 };

    //directions variables
    public static GameObject leftDir, rightDir, upDir, downDir;
    public GameObject[] directions = { leftDir, rightDir, upDir, downDir };
    public SpriteRenderer sprite_leftDir, sprite_rightDir, sprite_upDir, sprite_downDir;
    public static Sprite dir_spriteDice1, dir_spriteDice2, dir_spriteDice3, dir_spriteDice4, dir_spriteDice5, dir_spriteDice6;
    public Sprite[] dir_sprites = { dir_spriteDice1, dir_spriteDice2, dir_spriteDice3, dir_spriteDice4, dir_spriteDice5, dir_spriteDice6 };
    public float dir_movement_right, dir_movement_up, dir_movement_down, dir_movement_left;

    public LayerMask whatStopsMovement;
    public int upwardFace = 1;

    //Audio
    public AudioSource audio_source;
    public AudioClip enemy_kill_clip;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        player_pos = GetComponent<Transform>();
        sprite_renderer = GetComponent<SpriteRenderer>(); 
        movePoint.parent = null;
    }

    void Update()
    {
        SpriteRefresher();
        //Always displays the right sprites based on the upward face.

        player_pos.position = Vector3.MoveTowards(player_pos.position, movePoint.position, moveSpeed * Time.deltaTime);
        //The player always move to the target position. We don't move the player we move the target, the player will follow it. I can make this slower by doing this moveSpeed/2.
        
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && stage == 1)
        {
            for (int i = 0; i <= 3; i++)
                directions[i].SetActive(true);
        }
        else if (stage != 1)
        {
            for (int i = 0; i <= 3; i++)
                directions[i].SetActive(false);
        }
        //Disables the directions when moving.

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "Enemy" )
        {
            Destroy(other.gameObject);
            audio_source.PlayOneShot(enemy_kill_clip);
            StartCoroutine(Camera_Prop.Shake_Camera(.15f, .4f));
            Timer_Controller.time_remaining += 1f;
        }

        if (other.gameObject.tag == "Spawner")
        {
            Destroy(other.gameObject);
            audio_source.PlayOneShot(enemy_kill_clip);
            StartCoroutine(Camera_Prop.Shake_Camera(.15f, .8f));
            Timer_Controller.time_remaining += 3f;
        }
    }

    public void moveLeft()
    {
        round += 1;
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            for (int i = 1; i <= dir_movement_left; i++)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position -= new Vector3(1f, 0f, 0f);
                }
            }
        } 

        switch (upwardFace)
        {
            case 6:
                upwardFace = 3;
                break;
            case 5:
                upwardFace = 3;
                break;
            case 4:
                upwardFace = 6;
                break;
            case 3:
                upwardFace = 6;
                break;
            case 2:
                upwardFace = 6;
                break;
            case 1:
                upwardFace = 3;
                break;
        }

        stage = 2;
    }

    public void moveRight()
    {
        round += 1;
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            for (int i = 1; i <= dir_movement_right; i++)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                }
            }
        }

        switch (upwardFace)
        {
            case 6:
                upwardFace = 4;
                break;
            case 5:
                upwardFace = 4;
                break;
            case 4:
                upwardFace = 1;
                break;
            case 3:
                upwardFace = 1;
                break;
            case 2:
                upwardFace = 1;
                break;
            case 1:
                upwardFace = 4;
                break;
        }

        stage = 2;
    }

    public void moveDown()
    {
        round += 1;
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            for (int i = 1; i <= dir_movement_down; i++)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position -= new Vector3(0f, 1f, 0f);
                }
            }   
        }

        switch (upwardFace)
        {
            case 6:
                upwardFace = 2;
                break;
            case 5:
                upwardFace = 6;
                break;
            case 4:
                upwardFace = 2;
                break;
            case 3:
                upwardFace = 5;
                break;
            case 2:
                upwardFace = 3;
                break;
            case 1:
                upwardFace = 5;
                break;
        }
        stage = 2;
    }

    public void moveUp()
    {
        round += 1;
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            for (int i = 1; i <= dir_movement_up; i++)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
            }
        }

        switch (upwardFace)
        {
            case 6:
                upwardFace = 5;
                break;
            case 5:
                upwardFace = 1;
                break;
            case 4:
                upwardFace = 5;
                break;
            case 3:
                upwardFace = 2;
                break;
            case 2:
                upwardFace = 4;
                break;
            case 1:
                upwardFace = 2;
                break;
        }
        stage = 2;
    }

    public void SpriteRefresher()
    {
        if (upwardFace == 1)
        {
            sprite_renderer.sprite = sprites[0];

            sprite_leftDir.sprite = dir_sprites[2];
            sprite_rightDir.sprite = dir_sprites[3];
            sprite_upDir.sprite = dir_sprites[1];
            sprite_downDir.sprite = dir_sprites[4];

            dir_movement_down = 5f;
            dir_movement_left = 3f;
            dir_movement_right = 4f;
            dir_movement_up = 2f;
        }
        else if (upwardFace == 2)
        {
            sprite_renderer.sprite = sprites[1];

            sprite_leftDir.sprite = dir_sprites[5];
            sprite_rightDir.sprite = dir_sprites[0];
            sprite_upDir.sprite = dir_sprites[3];
            sprite_downDir.sprite = dir_sprites[2];

            dir_movement_down = 3f;
            dir_movement_left = 6f;
            dir_movement_right = 1f;
            dir_movement_up = 4f;
        }
        else if (upwardFace == 3)
        {
            sprite_renderer.sprite = sprites[2];

            sprite_leftDir.sprite = dir_sprites[5];
            sprite_rightDir.sprite = dir_sprites[0];
            sprite_upDir.sprite = dir_sprites[1];
            sprite_downDir.sprite = dir_sprites[4];

            dir_movement_down = 5f;
            dir_movement_left = 6f;
            dir_movement_right = 1f;
            dir_movement_up = 2f;
        }
        else if (upwardFace == 4)
        {
            sprite_renderer.sprite = sprites[3];

            sprite_leftDir.sprite = dir_sprites[5];
            sprite_rightDir.sprite = dir_sprites[0];
            sprite_upDir.sprite = dir_sprites[4];
            sprite_downDir.sprite = dir_sprites[1];

            dir_movement_down = 2f;
            dir_movement_left = 6f;
            dir_movement_right = 1f;
            dir_movement_up = 5f;
        }
        else if (upwardFace == 5)
        {
            sprite_renderer.sprite = sprites[4];

            sprite_leftDir.sprite = dir_sprites[2];
            sprite_rightDir.sprite = dir_sprites[3];
            sprite_upDir.sprite = dir_sprites[0];
            sprite_downDir.sprite = dir_sprites[5];

            dir_movement_down = 6f;
            dir_movement_left = 3f;
            dir_movement_right = 4f;
            dir_movement_up = 1f;

        }
        else if (upwardFace == 6)
        {
            sprite_renderer.sprite = sprites[5];

            sprite_leftDir.sprite = dir_sprites[2];
            sprite_rightDir.sprite = dir_sprites[3];
            sprite_upDir.sprite = dir_sprites[4];
            sprite_downDir.sprite = dir_sprites[1];

            dir_movement_down = 2f;
            dir_movement_left = 3f;
            dir_movement_right = 4f;
            dir_movement_up = 5f;
        }
    }

}
