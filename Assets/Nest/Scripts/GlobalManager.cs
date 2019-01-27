using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {
    public static GlobalManager instance = null;
    public bool isSoundOn=true;
    public AudioSource audioSource;
    public AudioClip[]  audioClip;
    public static int i;
    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audioSource.clip = audioClip[i];
        audioSource.Play();
    }

    // Update is called once per frame
        void Update () {
		
	}
}
