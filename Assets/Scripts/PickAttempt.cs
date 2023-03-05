using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PickAttempt : MonoBehaviour
{
    [SerializeField]
    private PreviousAttempt previousAttempt;

    [SerializeField]
    private AttemptedPosition attemptedPosition;
    private string previousShape;

    private void Awake()
    {
        previousShape = "";
    }

    public void TakeAttempt()
    {
        if (previousAttempt.previousAttemptShape.Count != 0)
        {
            previousShape = previousAttempt.previousAttemptShape.Dequeue();
        }
        if (previousShape == "" || previousShape == "X")
        {
            this.GetComponentInChildren<TMP_Text>().text = "0";
        }
        else
        {
            this.GetComponentInChildren<TMP_Text>().text = "X";
        }
        previousAttempt.previousAttemptShape.Enqueue(this.GetComponentInChildren<TMP_Text>().text);
        GetComponent<EventTrigger>().enabled = false;
        previousAttempt.attemptCount++;
        if (previousAttempt.attemptCount >= 5)
        {
            attemptedPosition.checkTicTac.Invoke();
        }
        if (previousAttempt.attemptCount == 9)
            attemptedPosition.restartButton.SetActive(true);
    }
}
