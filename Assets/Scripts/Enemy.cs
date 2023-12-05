using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Animator animator;

    public int maxHealth = 100;
    public bool isFlipped = false;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hit animation
        animator.SetTrigger("Hit");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemi ded");

        // Die animation
        animator.SetBool("isDead", true);

        // Disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        // Destroy(gameObject);
    }
}
