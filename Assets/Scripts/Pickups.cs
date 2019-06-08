using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {
	
	public float range = 0.0f;
	public float speed = 0.0f;
	public Transform player;
	public Transform me;
	public Vector3 lookDir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
 if(Vector3.Distance(player.position, me.position) <= range){
	      lookDir = player.position-me.position;
 lookDir.y = 0; // keep only the horizontal direction
 me.rotation = Quaternion.LookRotation(lookDir);
	 me.position += me.forward*speed*Time.deltaTime;
 }
  if(Vector3.Distance(player.position, me.position) <= 1f){
	  Destroy(gameObject);
  }
	}
}
