using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private GameObject gamePlayPanel;
    [SerializeField] private GameObject gameEndPanel;

    [SerializeField] private TextMeshProUGUI gameEndLevelStatusText;

    [SerializeField] private Animator UIAnimController;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    private void Start()
    {
        UIAnimController.Play("GameStart");
        gameStartPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
    }

    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void OnClick_Start()
    {
        UIAnimController.Play("LevelStart");

        // Start Game
        GameManager.Instance.StartGame();
    }

    public void ShowGameEndPanel(bool isCompleted = false)
    {
        gameStartPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        gameEndPanel.SetActive(true);

        if (isCompleted)
        {
            gameEndLevelStatusText.text = "Level Completed";
        }
        else
        {
            gameEndLevelStatusText.text = "Level Failed";
        }
        UIAnimController.Play("LevelEnd");
    }
}
