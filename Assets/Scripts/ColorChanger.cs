using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Material newColor;
    [SerializeField] AudioSource ChangeSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeColor(other.gameObject);
        }
    }

    private void ChangeColor(GameObject player)
    {
        Renderer rendererGracza = player.GetComponent<Renderer>();
        rendererGracza.material = newColor;
        ChangeSound.Play();
    }
}