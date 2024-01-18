using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.PlayMusic(MusicType.HappyMusic);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.PlaySFX(SFXType.ClickSound);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            AudioManager.instance.PlaySFX(SFXType.ShootSound);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("NextScene");
        }
    }
}
