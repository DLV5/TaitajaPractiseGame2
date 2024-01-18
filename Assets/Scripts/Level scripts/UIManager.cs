using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;

    public void ShowLoseScreen()
    {
        _loseScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        _winScreen.SetActive(true);
    }
}
