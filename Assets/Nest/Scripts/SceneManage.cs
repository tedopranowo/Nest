using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour {
    public GameObject Credit;
    
    public void nextscene(string Gameplay)
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Gameplay");
        
    }
    public void OnCredit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Credit.SetActive(false);
        }
    }
    public void backscene(string Menu)
    {
        Debug.Log("Resume!");
        
    }
    public void Quit()
    {
        Debug.Log("Active");
        Application.Quit();
    }
}
