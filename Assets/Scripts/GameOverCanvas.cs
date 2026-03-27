using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    public static GameOverCanvas Instance { get; private set; }
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {

        }

        Deactivate();
    }
    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }
    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
