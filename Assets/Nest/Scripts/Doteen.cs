using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Doteen : MonoBehaviour {

    public Vector3 posisi;
	// Use this for initialization
	void Start () {
        posisi = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,transform.position.z);
        gameObject.transform.DOScale(new Vector3(10, 10), 2f).SetLoops(4, LoopType.Yoyo).SetSpeedBased(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
