using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    float smoothDampTime = 0.08f; // Adjust this value to control the smoothness of the movement
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        //transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);

        Vector3 currentVelocity = Vector3.zero;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothDampTime);
    }
}
