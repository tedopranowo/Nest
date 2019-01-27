using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {
    public static GlobalManager instance = null;
    public bool isSoundOn=true;
    public AudioSource audioSource;
    public AudioClip bgm;

    public AudioClip soundClick;
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
        audioSource.clip = bgm;
        audioSource.Play(); //BGM
    }

    // Update is called once per frame
    void Update () {
		
	}
}
