using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBut : MonoBehaviour
{
    [SerializeField] private AudioSource clickBut;

    public void LoadLevelNext(int level)
    {
        clickBut.Play();
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
        HeartSystem.health = 5;
        PowerSystem.powerBar = 0;
    }

    public void LoadLevelNextTwo(int level)
    {
        clickBut.Play();
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
        HeartSystem.health = 5;
        PowerSystem.powerBar = 2;
    }

    public void LoadLevelNextThree(int level)
    {
        clickBut.Play();
        SceneManager.LoadScene(level);
        Time.timeScale = 1f;
        HeartSystem.health = 5;
        PowerSystem.powerBar = 3;
    }
}
