using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTopUp : MonoBehaviour
{
    public GameObject win;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource winStop;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            winStop.Stop();
            winSound.Play();
            win.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
