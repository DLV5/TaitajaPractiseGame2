using UnityEngine;

public enum FoodType
{
    Lion,
    Gorila,
    Elephant,
    Python
}

public class Food : MonoBehaviour
{
    [SerializeField] private FoodType type;

    public FoodType GetFoodType()
    {
        return type;
    }
}
