using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerOrder : MonoBehaviour
{
    PortalSpawn portalSpawn;

    void Awake()
    {
        portalSpawn = portalSpawn.GetComponent<PortalSpawn>();
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        Die();
    }

    private void Die()
    {
        StartCoroutine(Respawn(3f));
        portalSpawn.spawnObjects();
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}
