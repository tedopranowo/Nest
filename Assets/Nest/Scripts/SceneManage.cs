using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManage : MonoBehaviour {
    public GameObject Credit;
    public GameObject title;
    public GameObject tulisan;
    public GameObject Tutorial;
    public GameObject btnPlay, btnSoundOn, btnSoundOff, btnI;
    
  
    public void Backscene(string back)
    {
        SceneManager.LoadScene("Menu");
    }
    public void Nextscene(string Gameplay)
    {
        GlobalManager.instance.audioSource.PlayOneShot(GlobalManager.instance.soundClick); //SFX

        SceneManager.LoadScene(Gameplay);
        Time.timeScale = 1f;
        GlobalManager.instance.audioSource.Play();
    }
    public void Back()
    {
        GlobalManager.instance.audioSource.PlayOneShot(GlobalManager.instance.soundClick); //SFX

        Credit.SetActive(false);
        tulisan.SetActive(true);
        title.SetActive(true);
        btnPlay.SetActive(true);
        btnSoundOn.SetActive(true);
        btnI.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Credit.SetActive(false);
            tulisan.SetActive(true);
            title.SetActive(true);
            btnPlay.SetActive(true);
            btnSoundOn.SetActive(true);
            //btnSoundOff.SetActive(true);
            btnI.SetActive(true);
        }
    }
   
    public void OnCredit()
    {
        GlobalManager.instance.audioSource.PlayOneShot(GlobalManager.instance.soundClick); //SFX

        Credit.SetActive(true);
        tulisan.SetActive(false);
        title.SetActive(false);
        btnPlay.SetActive(false);
        btnSoundOn.SetActive(false);
        btnSoundOff.SetActive(false);
        btnI.SetActive(false);
        //GlobalManager.instance.audioSource.volume = 1;
    }

    public void Resume()
    {

        tulisan.SetActive(true);
    }
    public void SoundOn()
    {
        GlobalManager.instance.audioSource.PlayOneShot(GlobalManager.instance.soundClick); //SFX

        Debug.Log("SoundOn!");
        btnSoundOn.SetActive(true);
        btnSoundOff.SetActive(false);
        GlobalManager.instance.audioSource.volume = 1;
    }
    public void SoundOff()
    {
        GlobalManager.instance.audioSource.PlayOneShot(GlobalManager.instance.soundClick); //SFX

        Debug.Log("SoundOff!");
        btnSoundOn.SetActive(false);
        btnSoundOff.SetActive(true);
        GlobalManager.instance.audioSource.volume = 0;
    }
    public void Quit()
    {
        GlobalManager.instance.audioSource.PlayOneShot(GlobalManager.instance.soundClick); //SFX

        Debug.Log("Active");
        Application.Quit();
    }
}
