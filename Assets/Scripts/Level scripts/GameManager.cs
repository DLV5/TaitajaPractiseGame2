using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private int _numberOfAnimalsToFeed;

    private GameBootstrap _bootstrap;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        _bootstrap = new GameBootstrap(_numberOfAnimalsToFeed);
    }

    private void OnEnable()
    {
        _bootstrap.FullAnimalsCounter.OnTaretNumberReached += OnAllAnimalsGotRightFood;
    }

    private void OnDisable()
    {
        _bootstrap.FullAnimalsCounter.OnTaretNumberReached -= OnAllAnimalsGotRightFood;
    }

    private void OnAnimalGotWrongFood()
    {
        _uiManager.ShowLoseScreen();
    }

    private void OnAllAnimalsGotRightFood()
    {
        _uiManager.ShowWinScreen();
    }

    //Will transfer to a next scene after short animation
    private void MoveToNextLevel()
    {
        _sceneFader.FadeIn();
    }
}
