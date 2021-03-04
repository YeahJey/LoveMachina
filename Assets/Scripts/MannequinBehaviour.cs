using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinBehaviour : MonoBehaviour, IHealth
{
    public float health { get; set; }
    public Animator animator;
    public Rigidbody2D rb;
    [SerializeField] GameObject player;

    private void Start()
    {
        health = 100;
    }
    public void ChangeHealth(float amount)
    {
        health -= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void FixedUpdate()
    {
        if (animator.GetBool("Attacked"))
        {
            var direction = transform.position - player.transform.position;
            rb.MovePosition((Vector2)transform.position + (Vector2)direction.normalized * 0.2f);
        }
    }
}
