using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartActivity : MonoBehaviour
{
    private Button restartButton;

    private void Awake()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(
            delegate
            {
                SceneManager.LoadScene(0);
            }
        );
    }
}
