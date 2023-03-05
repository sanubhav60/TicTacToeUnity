using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public delegate void CheckTicTac();
public delegate void ResultTicTac();

public class AttemptedPosition : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] imageTransform;
    public GameObject restartButton;
    public CheckTicTac checkTicTac;
    public ResultTicTac resultTicTac;
    private const int row = 3;
    private const int column = 3;
    private bool rowTest = true;
    private bool columnTest = true;
    private bool firstDiagonalTest = true;
    private bool secondDiagonalTest = true;
    private RectTransform[,] matrixPosition;
    private RectTransform[] correctPosition;

    private void Awake()
    {
        int m = 0;
        correctPosition = new RectTransform[row];
        matrixPosition = new RectTransform[row, column];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                matrixPosition[i, j] = imageTransform[m];
                if (m < imageTransform.Length - 1)
                    m++;
            }
        }
        checkTicTac = CheckHorizontally;
        checkTicTac += CheckVertically;
        checkTicTac += CheckLeftDiagonally;
        checkTicTac += CheckRightDiagonally;
        resultTicTac = ChangeColor;
    }

    private void CheckHorizontally()
    {
        int j = 0;
        for (int i = 0; i < row; i++)
        {
            if (
                (
                    matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text
                    == matrixPosition[i, j + 1].GetComponentInChildren<TMP_Text>().text
                )
                && (
                    matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text
                    == matrixPosition[i, j + 2].GetComponentInChildren<TMP_Text>().text
                )
                && (matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text != "")
            )
            {
                correctPosition[0] = matrixPosition[i, j];
                correctPosition[1] = matrixPosition[i, j + 1];
                correctPosition[2] = matrixPosition[i, j + 2];
                resultTicTac.Invoke();
                DisableBlockClicks(true, false);
                return;
            }
        }
    }

    private void CheckVertically()
    {
        int i = 0;
        for (int j = 0; j < column; j++)
        {
            if (
                (
                    matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text
                    == matrixPosition[i + 1, j].GetComponentInChildren<TMP_Text>().text
                )
                && (
                    matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text
                    == matrixPosition[i + 2, j].GetComponentInChildren<TMP_Text>().text
                )
                && (matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text != "")
            )
            {
                correctPosition[0] = matrixPosition[i, j];
                correctPosition[1] = matrixPosition[i + 1, j];
                correctPosition[2] = matrixPosition[i + 2, j];
                resultTicTac.Invoke();
                DisableBlockClicks(true, false);
                return;
            }
        }
    }

    private void CheckRightDiagonally()
    {
        int i = 0;
        if (
            (
                matrixPosition[i, i].GetComponentInChildren<TMP_Text>().text
                == matrixPosition[i + 1, i + 1].GetComponentInChildren<TMP_Text>().text
            )
            && (
                matrixPosition[i, i].GetComponentInChildren<TMP_Text>().text
                == matrixPosition[i + 2, i + 2].GetComponentInChildren<TMP_Text>().text
            )
            && (matrixPosition[i, i].GetComponentInChildren<TMP_Text>().text != "")
        )
        {
            correctPosition[0] = matrixPosition[i, i];
            correctPosition[1] = matrixPosition[i + 1, i + 1];
            correctPosition[2] = matrixPosition[i + 2, i + 2];
            resultTicTac.Invoke();
            DisableBlockClicks(true, false);
            return;
        }
    }

    private void CheckLeftDiagonally()
    {
        int i = 0;
        int j = row - 1;
        if (
            (
                matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text
                == matrixPosition[i + 1, j - 1].GetComponentInChildren<TMP_Text>().text
            )
            && (
                matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text
                == matrixPosition[i + 2, j - 2].GetComponentInChildren<TMP_Text>().text
            )
            && (matrixPosition[i, j].GetComponentInChildren<TMP_Text>().text != "")
        )
        {
            correctPosition[0] = matrixPosition[i, j];
            correctPosition[1] = matrixPosition[i + 1, j - 1];
            correctPosition[2] = matrixPosition[i + 2, j - 2];
            resultTicTac.Invoke();
            DisableBlockClicks(true, false);
            return;
        }
    }

    private void ChangeColor()
    {
        for (int i = 0; i < correctPosition.Length; i++)
        {
            correctPosition[i].GetComponent<Image>().color = Color.gray;
        }
        restartButton.SetActive(true);
    }

    private void DisableBlockClicks(bool currentStatus, bool newStatus)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (matrixPosition[i, j].GetComponent<EventTrigger>().enabled == currentStatus)
                    matrixPosition[i, j].GetComponent<EventTrigger>().enabled = newStatus;
            }
        }
    }
}
