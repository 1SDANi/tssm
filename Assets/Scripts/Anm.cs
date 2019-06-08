using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anm : MonoBehaviour {
	
	public Animator anm;
	public GameObject karateglove;
	public float waitr = 0.0f;
	public float waitr1 = 0.0f;
	public int w = 0;

	// Use this for initialization
	void Start () {
	anm = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetButtonDown("X")){w=1; anm.Play ("Karate Chop"); StartCoroutine(wait());}
	if(Input.GetButtonDown("A")){w=1; anm.Play ("jump02 start"); StartCoroutine(wait1());}
	if(Input.GetAxis("LSY")>0.3){if(w==0){anm.Play ("Tough Walk");}}
	}
	
	IEnumerator wait()
	{
    karateglove.active=true;
	yield return new WaitForSeconds(waitr);
    karateglove.active=false;
	w=0;
	}
	
	IEnumerator wait1()
	{
	yield return new WaitForSeconds(waitr1);
	w=0;
	}
}
