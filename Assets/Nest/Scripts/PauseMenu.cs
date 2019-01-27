using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool IsPaused = false;
    public GameObject PausedMenu;

	// Update is called once per frame
	void Update () {
        
	}
    public void OnMenu()
    {
        PausedMenu.SetActive(true);
        if (PausedMenu == true)
        {
            Time.timeScale = 0f;
            GlobalManager.instance.audioSource.volume = 0.25f;
            IsPaused = true;
        }
    }

    public void Resume()
    {
        PausedMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Retry(string Gameplay)
    {
        SceneManager.LoadScene(Gameplay);
        Time.timeScale = 1f;
        GlobalManager.instance.audioSource.PlayDelayed(0.5f);
    }

    public void QuittingGame(string Menu)
    {
        SceneManager.LoadScene(Menu);
        GlobalManager.instance.audioSource.Stop();
    }

}
