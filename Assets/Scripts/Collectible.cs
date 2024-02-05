using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float height = 0.5f;
    [SerializeField] AudioSource PointSound;
    Vector3 pos;
    public event Action pickupEvent;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickupEvent?.Invoke();
            PointSound.Play();
            gameObject.GetComponent<SphereCollider>().isTrigger = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}