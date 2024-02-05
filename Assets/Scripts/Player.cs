using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player instance;

    Rigidbody rb;
    public float movementSpeed = 6f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask ground;
    public AudioSource jump;

    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        CheckHealth();
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jump.Play();
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            PauseMenu.instance.deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameManager.instance.score = 0;
            ResetPlayerHealth();
        }
    }

    private void ResetPlayerHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
}
