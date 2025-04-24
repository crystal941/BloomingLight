using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    public void StartGame()
    {
        StartCoroutine(PlayClickThen(() => SceneManager.LoadScene("GameScene_BloomingLight")));
    }

    public void ExitGame()
    {
        StartCoroutine(PlayClickThen(() => Application.Quit()));
        Debug.Log("Quit Game");
    }


    private IEnumerator PlayClickThen(System.Action nextAction)
    {
        PlayClick();
        yield return new WaitForSeconds(clickSound.length); // Wait until sound finishes
        nextAction.Invoke();
    }


    public void RestartGame()
    {
        StartCoroutine(PlayClickThenReload());
    }

    public void GoToMenu()
    {
        StartCoroutine(PlayClickThenMenu());
    }

    private IEnumerator PlayClickThenReload()
    {
        PlayClick();
        yield return new WaitForSeconds(audioSource.clip.length); // wait for click sound to finish
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator PlayClickThenMenu()
    {
        PlayClick();
        yield return new WaitForSeconds(audioSource.clip.length); // wait for click sound to finish
        SceneManager.LoadScene("MenuScene_BloomingLight");
    }


    private void PlayClick()
    {
        Debug.Log("PlayClick triggered!");
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }


    private void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
        Debug.Log("Manually testing sound");
        PlayClick();
    }
    }
}
