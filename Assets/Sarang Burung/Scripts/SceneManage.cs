using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour {
    public bool IsChange;
    
    public void nextscene(string scene)
    {
        SceneManager.LoadScene(scene);

    }
    void OnClick()
    {
        
    }

}
