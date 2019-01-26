using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour {
    public GameObject Credit;
    public GameObject HTP;
    
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
            HTP.SetActive(false);
        }
    }
    public void How_To_Play()
    {
        HTP.SetActive(true);
    }

    public void OnCredit()
    {
        Credit.SetActive(true);
    }
   
    public void Resume()
    {
        Debug.Log("Resume!");
        
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
