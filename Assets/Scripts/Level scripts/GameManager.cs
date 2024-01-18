using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// This method changes a lose screen message on our exeption message
    /// </summary>
    /// <param name="exeption"></param>
    public void OnExeptionIncome(string exeption)
    {
        _uiManager.ChangeLoseScreenText(exeption);
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
}
