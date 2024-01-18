using System;

/// <summary>
/// This class used to count all animals who recieved the right food
/// </summary>
public class FullAnimalsCounter
{
    public event Action OnTaretNumberReached;

    public int Counter {  get; private set; }
    public int NumberOfAnimalsToFeed {  get; private set; }

    public FullAnimalsCounter(int numberOfAnimalsToFeed)
    {
        Initialize(numberOfAnimalsToFeed);
    }

    public void Initialize(int numberOfAnimalsToFeed)
    {
        NumberOfAnimalsToFeed = numberOfAnimalsToFeed;

        ResetCounter();
    }

    public void Add()
    {
        Counter++;

        if(Counter == NumberOfAnimalsToFeed) 
        {
            OnTaretNumberReached?.Invoke();
        }
    }

    private void ResetCounter()
    {
        Counter = 0; 
    }

}
