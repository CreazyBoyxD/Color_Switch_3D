﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioSource collectSound;

	public GameObject collectEffect;

	void Update() {

		if (rotate)
			transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect();
		}
	}

	public void Collect()
	{
		if (collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		collectSound.Play();

		gameObject.GetComponent<SphereCollider>().isTrigger = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
}
