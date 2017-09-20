﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	float speed = 15.0f;

	public float padding = 1f;


	float xmin;
	float xmax;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		}

		float newX = Mathf.Clamp(transform.position.x, this.xmin, this.xmax);

		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
