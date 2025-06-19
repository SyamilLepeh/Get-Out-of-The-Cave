using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickButTwo;
    public Animator anim;
    public GameObject anime;
    public GameObject text;
    public GameObject evil;
    public GameObject nextButton;

    void Start()
    {
        anime.SetActive(false);
        text.SetActive(false);
        evil.SetActive(false);
        nextButton.SetActive(false);

    }

    public void PlayGame()
    {
        clickButTwo.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        clickButTwo.Play();
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void PlaySound()
    {
        clickButTwo.Play();
    }

    public void AnimationPanel()
    {
        clickButTwo.Play();
        anime.SetActive(true);
        anim.SetBool("fadeOut", true);
        StartCoroutine(TransitionBool(1.5f));
    }

    IEnumerator TransitionBool(float masa)
    {
        yield return new WaitForSeconds(masa);
        text.SetActive(true);
        evil.SetActive(true);
        yield return new WaitForSeconds(masa);
        nextButton.SetActive(true);
    }

}
