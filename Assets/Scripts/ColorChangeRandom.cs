using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeRandom : MonoBehaviour
{
    [SerializeField] List<Material> colorMaterials;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeColor(other.gameObject);
        }
    }

    private void ChangeColor(GameObject player)
    {
        Renderer playerRenderer = player.GetComponent<Renderer>();
        int randomIndex = Random.Range(0, colorMaterials.Count);
        playerRenderer.material = colorMaterials[randomIndex];
    }
}
