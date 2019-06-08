using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfol : MonoBehaviour {
	public Transform me;
	public Transform camr;
	public float rotatespeed = 0.0f;
	public float extrax = 0.0f;
	public float extray = 0.0f;
	public float extraz = 0.0f;
	public float inx = 0.0f;
	public float iny = 0.0f;
	public float inr = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
				inx=Input.GetAxis("LSX");
		iny=Input.GetAxis("LSY");
		inr=inx+iny;
		if(inr>1){inr=1;}
	camr.position=new Vector3(me.position.x-extrax, me.position.y+extray, me.position.z+extraz);
	//if(Input.GetAxis("LSX")>0){transform.Rotate(Vector3.up*rotatespeed*Time.deltaTime);}
	//if(Input.GetAxis("LSX")<-0){transform.Rotate(Vector3.down*rotatespeed*Time.deltaTime);}
	}
}
