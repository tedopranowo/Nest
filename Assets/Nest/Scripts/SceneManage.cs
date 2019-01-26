using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour {
    public GameObject Credit;
    public GameObject title;
    public GameObject tulisan;
    public GameObject btnPlay, btnSound, btnI;
    
    public void backscene(string back)
    {
        SceneManager.LoadScene("Menu");
    }
    public void nextscene(string Gameplay)
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Gameplay");
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Credit.SetActive(false);
            tulisan.SetActive(true);
            title.SetActive(true);
            btnPlay.SetActive(true);
            btnSound.SetActive(true);
            btnI.SetActive(true);
        }
    }
    public void How_To_Play()
    {
        title.SetActive(true);
    }

    public void OnCredit()
    {
        Credit.SetActive(true);
        tulisan.SetActive(false);
        title.SetActive(false);
        btnPlay.SetActive(false);
        btnSound.SetActive(false);
        btnI.SetActive(false);

    }

    public void Resume()
    {
        Debug.Log("Resume!");
        tulisan.SetActive(true);
    }

    public void Retry()
    {
        Debug.Log("Retry!");
        SceneManager.LoadScene("Gameplay");
    }
    public void Quit()
    {
        Debug.Log("Active");
        Application.Quit();
    }
}
