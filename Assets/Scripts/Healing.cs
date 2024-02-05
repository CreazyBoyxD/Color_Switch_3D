using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player.instance.currentHealth = 5;
            Player.instance.healthBar.SetMaxHealth(Player.instance.maxHealth);
        }
    }
}
