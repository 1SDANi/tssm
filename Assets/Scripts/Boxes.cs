using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour {
	
	public float range=0.0f;
	public float yrange=0.0f;
	public Transform player;
	public Transform me;
	public Transform frag1;
	public Transform frag2;
	public Transform frag3;
	public Transform frag4;
	public Transform frag5;
	public Transform frag6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    if( Vector3.Distance( player.position, me.position) <= range ){
	//if( Vector3.Distance( player.position.y, me.position.y) <= yrange ){
	if(Input.GetMouseButtonDown(0)){
	Instantiate(frag1, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag2, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag3, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag4, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag5, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag6, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Destroy(gameObject);
	}
	if(Input.GetButtonDown("X")){
	Instantiate(frag1, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag2, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag3, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag4, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag5, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Instantiate(frag6, new Vector3(me.position.x, me.position.y+0.5f, me.position.z),  Quaternion.identity);
	Destroy(gameObject);
	}
	}
	}
}
