using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsBehavior : MonoBehaviour
{
    Material materialSciany;
    BoxCollider boxCollider;
    GameObject player;
    private bool isKnockingBack = false;
    private float knockbackEndTime;
    public float knockbackDuration = 0.5f;
    public float knockbackStrength = 5f;
    public AudioSource DamageSound;

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        materialSciany = renderer.material;
    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isKnockingBack)
        {
            if (Time.time < knockbackEndTime)
            {
                Rigidbody rb = Player.instance.GetComponent<Rigidbody>();
                Vector3 direction = (Player.instance.transform.position - transform.position).normalized;
                direction.y = 0;

                float currentStrength = Mathf.Lerp(0, knockbackStrength, (knockbackEndTime - Time.time) / knockbackDuration);
                rb.AddForce(direction * currentStrength, ForceMode.Impulse);
            }
            else
            {
                isKnockingBack = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CompareColor(collision.gameObject);
        }
    }

    private void CompareColor(GameObject player)
    {
        Renderer rendererGracza = player.GetComponent<Renderer>();
        Material materialGracza = rendererGracza.material;

        if (materialGracza.color == materialSciany.color)
        {   
            boxCollider.enabled = false;
            Invoke("colliderON", 1f);
        }
        else
        {
            boxCollider.enabled = true;
            TakeDamage(1);
            DamageSound.Play();
        }
    }

    void colliderON()
    {
        boxCollider.enabled = true; 
    }

    public void TakeDamage(int damage)
    {
        Player.instance.currentHealth -= damage;
        Player.instance.healthBar.SetHealth(Player.instance.currentHealth);

        isKnockingBack = true;
        knockbackEndTime = Time.time + knockbackDuration;
    }
}
