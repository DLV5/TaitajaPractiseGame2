/// <summary>
/// This class used to initialize all non-monobexavior objects for game
/// </summary>
public class GameBootstrap
{
    public FullAnimalsCounter FullAnimalsCounter { get; private set; }

    public GameBootstrap(int numberOfAnimalsToFeed) 
    {
        Initialize(numberOfAnimalsToFeed);
    }

    public void Initialize(int numberOfAnimalsToFeed)
    {
        FullAnimalsCounter = new FullAnimalsCounter(numberOfAnimalsToFeed);
    }
}
