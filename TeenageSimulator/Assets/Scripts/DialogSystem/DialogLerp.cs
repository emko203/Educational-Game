using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLerp : MonoBehaviour
{

    private bool shouldLerp = false;
    public float timeStartingLerping;
    public float lerpTime;

    public Vector2 startPosition;
    public Vector2 endPosition;

    public void StartLerping()
    {
        timeStartingLerping = Time.time;
        shouldLerp = true;
    }

    private void Update()
    {
        if (shouldLerp)
        {
            transform.position = Lerp(startPosition, endPosition, timeStartingLerping, lerpTime);
        }

    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeStartedLerping / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
