using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private TMP_Text _loseScreenText;

    [SerializeField] private GameObject _winScreen;

    public void ShowLoseScreen()
    {
        _loseScreen.SetActive(true);
    }

    public void ChangeLoseScreenText(string text)
    {
        _loseScreenText.text = text;
    }

    public void ShowWinScreen()
    {
        _winScreen.SetActive(true);
    }
}
