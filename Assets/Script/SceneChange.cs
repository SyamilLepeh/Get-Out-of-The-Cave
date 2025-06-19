using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private AudioSource clickButton;

    public void LoadLevelNext(int level)
    {
        clickButton.Play();
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
        HeartSystem.health = 5;
    }

    public void PlayGame()
    {
        clickButton.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}
