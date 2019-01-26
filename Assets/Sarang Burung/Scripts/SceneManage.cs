using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour {
    public GameObject Panel;
    
    public void nextscene(string Gameplay)
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Gameplay");
        
    }
    public void OnCredit()
    {
        Debug.Log("Credit");
        if(Panel != null)
        {
            Panel.SetActive(true);
        }   
        /*Panel = GameObject.FindWithTag("Credit").GetComponent<string>();
        if (IsChange != true)
        {

        }*/
    }
    public void Quit()
    {
        Debug.Log("Active");
        Application.Quit();
    }
}
