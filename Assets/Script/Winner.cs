using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public GameObject win;
    [SerializeField] private AudioSource winSoundThree;
    [SerializeField] private AudioSource winStopThree;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spawnable"))
        {
            winStopThree.Stop();
            winSoundThree.Play();
            win.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
