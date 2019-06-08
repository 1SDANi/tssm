using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerar : MonoBehaviour {
	public Transform me;
	public Transform camr;
	public Transform camfolx;
	public Transform camfoly;
	public float oldx = 0.0f;
	public float oldy = 0.0f;
	public float rotatespeedx = 0.0f;
	public float rotatespeedy = 0.0f;
	public float extrax = 0.0f;
	public float extray = 0.0f;
	public float extraz = 0.0f;
	public float x = 0.0f;
	public float y = 0.0f;
	public float z = 0.0f;
	

	// Use this for initialization
	void Start () {
		x=me.rotation.x;
		y=me.rotation.y;
		z=me.rotation.z;
		Cursor.lockState = CursorLockMode.Locked;
		//if(camr.position.x>me.position.x){extrax=camr.position.x-me.position.x;}else{extrax=me.position.x-camr.position.x;}
		//if(camr.position.y>me.position.y){extray=camr.position.y-me.position.y;}else{extray=me.position.y-camr.position.y;}
		//if(camr.position.z>me.position.z){extraz=camr.position.z-me.position.z;}else{extraz=me.position.z-camr.position.z;}
	}
	
	// Update is called once per frame
	void Update () {
	//camr.position=new Vector3(me.position.x-extrax, me.position.y+extray, me.position.z+extraz);
	//if(Input.GetAxis("Horizontal")>oldx){transform.Rotate(Vector3.up*rotatespeed*Time.deltaTime); oldx=Input.mousePosition.x;}
	//if(Input.GetAxis("Horizontal")<oldx){transform.Rotate(Vector3.down*rotatespeed*Time.deltaTime); oldx=Input.mousePosition.x;}
	//if(Input.GetAxis("Vertical")>oldy){camr.transform.Rotate(Vector3.right*rotatespeedc*Time.deltaTime); oldy=Input.mousePosition.y;}
	//if(Input.GetAxis("Vertical")<oldy){camr.transform.Rotate(Vector3.left*rotatespeedc*Time.deltaTime); oldy=Input.mousePosition.y;}
	
	
	if(Input.GetAxis("RSX")>=0.5){camfolx.transform.Rotate(Vector3.down*rotatespeedx*Time.deltaTime);}	
	if(Input.GetAxis("RSX")<=-0.5){camfolx.transform.Rotate(Vector3.up*rotatespeedx*Time.deltaTime);}	
	if(Input.GetAxis("RSY")>=0.5){camfoly.transform.Rotate(Vector3.right*rotatespeedy*Time.deltaTime);}	
	if(Input.GetAxis("RSY")<=-0.5){camfoly.transform.Rotate(Vector3.left*rotatespeedy*Time.deltaTime);}
	}
}
