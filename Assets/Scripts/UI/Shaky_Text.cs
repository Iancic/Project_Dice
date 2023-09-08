using System.Collections;
using UnityEngine;
public class Shaky_Text : MonoBehaviour
{
    public static Transform transform_text;

    private void Start()
    {
        transform_text = GetComponent<Transform>();
    }
    static public IEnumerator Shake_Streak(float duration, float multiplier)
    {
        Vector3 originalPos = transform_text.localPosition;
        //remembers the initial position

        float elapsed = 0.0f;
        //counter for the duration of shake

        while (elapsed < duration)
        {
            float x = Random.Range(-0.3f, 0.3f) * multiplier;
            float y = Random.Range(-0.3f, 0.3f) * multiplier;

            transform_text.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        //while the counter did not reach duration, move the camera in random positions on x and y.

        transform_text.localPosition = originalPos;
        //reset the camera to inital position
    }
}