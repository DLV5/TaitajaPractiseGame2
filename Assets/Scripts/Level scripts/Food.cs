using UnityEngine;

public enum FoodType
{
    Gorilla,
    Jaguar,
    Python,
    Elephant
}

public class Food : MonoBehaviour
{
    [SerializeField] private FoodType type;

    public FoodType GetFoodType()
    {
        return type;
    }
}
