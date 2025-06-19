using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonClick : MonoBehaviour
{
    [SerializeField] private AudioSource clickButtonPause;

    // Start is called before the first frame update
    public void PauseButton()
    {
        clickButtonPause.Play();
    }
}
