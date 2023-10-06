using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void OnLevelStarted();
    public event OnLevelStarted OnLevelStartedEvent;

    public delegate void OnLevelEnded();
    public event OnLevelStarted OnLevelEndedEvent;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }


    public void StartGame()
    {
        OnLevelStartedEvent?.Invoke();
    }

    public void EndGame()
    {
        OnLevelEndedEvent?.Invoke();
    }

}
