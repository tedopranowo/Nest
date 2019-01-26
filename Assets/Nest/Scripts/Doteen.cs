using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Doteen : MonoBehaviour {

    public Vector3 posisi;
    public static int dur = 20;
	// Use this for initialization
	void Start () {
        posisi = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.position.z);
            gameObject.transform.DOScale(new Vector3(2, 2), 2f).SetLoops(dur, LoopType.Yoyo).SetSpeedBased(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
