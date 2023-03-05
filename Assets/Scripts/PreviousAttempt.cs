using System.Collections.Generic;
using UnityEngine;

public class PreviousAttempt : MonoBehaviour
{
    public Queue<string> previousAttemptShape;

    [HideInInspector]
    public int attemptCount = 0;

    private void Awake()
    {
        previousAttemptShape = new Queue<string>();
    }
}
