using System.Collections;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public IEnumerator Shake_Camera (float duration, float multiplier)
    {
        Vector3 originalPos = transform.localPosition;
        //remembers the initial position

        float elapsed = 0.0f;
        //counter for the duration of shake

        while (elapsed < duration)
        {
            float x = Random.Range(-0.3f, 0.3f) * multiplier;
            float y = Random.Range(-0.3f, 0.3f) * multiplier;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        //while the counter did not reach duration, move the camera in random positions on x and y.

        transform.localPosition = originalPos;
        //reset the camera to inital position
    }
}
