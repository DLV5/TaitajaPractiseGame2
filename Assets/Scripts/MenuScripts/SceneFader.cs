using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _sceneName;

    public void FadeIn(string sceneName)
    {
        _animator.SetTrigger("FadeIn");
        _sceneName = sceneName;
    }

    //Invokes righ after animation is played
    public void TransferToScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
