using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private int _numberOfAnimalsToFeed;

    private AnimalController[] _animals;

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

        _animals = FindObjectsByType<AnimalController>(FindObjectsSortMode.InstanceID);
    }

    private void OnEnable()
    {
        _bootstrap.FullAnimalsCounter.OnTaretNumberReached += OnAllAnimalsGotRightFood;
    }

    private void OnDisable()
    {
        _bootstrap.FullAnimalsCounter.OnTaretNumberReached -= OnAllAnimalsGotRightFood;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// This method changes a lose screen message on our exeption message and ends a game
    /// </summary>
    /// <param name="exeption"></param>
    public void OnExeptionIncome(string exeption)
    {
        _uiManager.ChangeLoseScreenText(exeption);
        OnLose();
    }

    public void MoveAllanimals()
    {  
        foreach (var animal in _animals) 
        { 
            animal.StartMoving();
        }
    }

    public void OnAnimalAteRightFood() => _bootstrap.FullAnimalsCounter.Add();

    //Lose will happen if animal didnt got a food or got a wrong food
    private void OnLose()
    {
        _uiManager.ShowLoseScreen();
    }

    private void OnAllAnimalsGotRightFood()
    {
        _uiManager.ShowWinScreen();
    }
}
